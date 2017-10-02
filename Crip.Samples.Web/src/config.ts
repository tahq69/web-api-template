import utils from './utils'

const apiRoot = 'http://localhost:13162/api/'
const log = {
    logs: 'console',
    logSections: [
        'global',
        'api',
        'component',
        'error',
        'info',
    ]
}

export module config {

    export interface ILogConfig {
        logs: string
        logSections: string[]
    }

    export const Log = log

    export function ApiUrl(path: string, params = {}, urlReplace = {}) {
        let url = path.replace(new RegExp('^[\\/]+'), '')
        url = `${apiRoot}${url}`
        url = utils.supplant(url, urlReplace)

        Object.keys(params).forEach(index => {
            let val = params[index]
            if (typeof val !== 'undefined' && val !== '') {
                url = AddParameter(url, index, val)
            }
        })

        return url
    }

    export function AddParameter(url: string, param: string, value: string): string {
        // Using a positive lookahead (?=\=) to find the
        // given parameter, preceded by a ? or &, and followed
        // by a = with a value after than (using a non-greedy selector)
        // and then followed by a & or the end of the string
        const val = new RegExp(`(\\?|\\&)${param}=.*?(?=(&|$))`)
        const parts = url.toString().split('#')
        const hash = parts[1]
        const qstring = /\?.+$/
        let newURL = url = parts[0]

        // Check if the parameter exists
        if (val.test(url)) {
            // if it does, replace it, using the captured group
            // to determine & or ? at the beginning
            newURL = url.replace(val, `$1${param}=${value}`)
        } else if (qstring.test(url)) {
            // otherwise, if there is a query string at all
            // add the param to the end of it
            newURL = `${url}&${param}=${value}`
        } else {
            // if there's no query string, add one
            newURL = `${url}?${param}=${value}`
        }

        if (hash) {
            // if hash exists, append it to new url
            newURL += `#${hash}`
        }

        return newURL
    }
}
