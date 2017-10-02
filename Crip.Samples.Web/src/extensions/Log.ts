import Vue from 'vue'
import { config } from '../config'
import utils from '../utils'

export module extensions {

    class Log {
        private logType: string;
        private sections: string[];

        public constructor(options: config.ILogConfig) {
            this.logType = options.logs
            this.sections = options.logSections
        }

        public log(...args: any[]) {
            this.writelog('log', args)
        }

        public info(...args: any[]) {
            this.writelog('info', args, 'info')
        }

        public error(...args: any[]) {
            this.writelog('error', args, 'error')
        }

        public group(section: string, type: LogType = 'log') {
            return (...args) => {
                args.unshift(section)
                this.writelog(type, args, section)
            }
        }

        public component(vm: Vue, ...args: any[]) {
            let route = { ...vm.$route.params, path: vm.$route.fullPath }
            let debugArgs = [`component ${vm.$options.name}`, { route }, ...args]

            this.writelog('debug', debugArgs, 'component')
        }

        public unknownApiError(error) {
            this.error('log.apiError -> unknown', error)
            // TODO: add user notification toast about error
            // TODO: send email as there happened something that we did not expected
        }

        public apiError(errorResponse, reject = _ => _) {
            if (utils.isUndefined(errorResponse)) {
                return this.unknownApiError(errorResponse)
            }

            let result = errorResponse.data

            if (errorResponse.status !== 406) {
                result = { error: ['Unknown error'] }
            }

            if (reject && typeof reject === 'function') {
                reject(result)
            }

            switch (errorResponse.status) {
                case 401:
                    this.error(
                        'log.apiError -> unauthorized',
                        errorResponse.data)
                    // store.commit('logout')
                    // router.push({ ...login, query: { redirect: router.currentRoute.fullPath } })
                    break
                case 406:
                    this.error(
                        'log.apiError -> validation failed',
                        errorResponse.data)
                    break
                case 403:
                case 405:
                    this.error(
                        'log.apiError -> method not allowed',
                        errorResponse)
                    // Vue.toasted.error('Action is not allowed')
                    // TODO: send this as email to admin to be able detect users who is trying hack app
                    //   or some places has not enough protection and simple user can open it and
                    //   create not allowed requests
                    break
            }

            return result
        }

        private writelog(type: LogType, args: any, section = 'global') {
            if (!this.isInAvailableSections(section)) return

            if (this.logType === 'console') {
                return this.consoleLog(type, args)
            }
        }

        private consoleLog(type: LogType, args: any) {
            if (window.console && console[type]) {
                console[type].apply(console, args)
            }
        }

        private isInAvailableSections(section: string): boolean {
            return utils.isInArray(section, this.sections)
        }
    }

    const logger = new Log(config.Log)

    export function install(vue: Vue) {
        Object.defineProperties(Vue, {
            '$log': { get: () => logger }
        })
    }

    export type LogType = 'log' | 'info' | 'warn' | 'debug' | 'error'

    export const Logger = logger
}
