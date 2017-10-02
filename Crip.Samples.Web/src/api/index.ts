import http from 'axios'
import { extensions } from '../extensions/Log'
import { config } from '../config'

export module api {
    export abstract class Base<T> {
        protected async Find<T>(path: string, id: number, urlReplace = {}, urlParams = {}): Promise<T> {
            let url = config.ApiUrl(`${path}/${id}`, urlParams, urlReplace)
            try {
                const { data } = await http.get(url)
                let result: T = <T>data
                extensions.Logger.group('api', 'debug')(url, result)
                return result
            } catch (error) {
                throw extensions.Logger.apiError(error)
            }
        }
    }
}
