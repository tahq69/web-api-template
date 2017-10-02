class Utils {
    public isUndefined(value: any): boolean {
        return typeof value === 'undefined'
    }

    public isDefined(value: any): boolean {
        return !this.isUndefined(value)
    }

    public isFunction(func: any): boolean {
        const getType = {}
        return (
            this.isDefined(func) &&
            getType.toString.call(func) === '[object Function]'
        )
    }

    public isEmpty(value: any): boolean {
        /* eslint-disable no-self-compare */
        return this.isUndefined(value) ||
            value === '' ||
            value === null ||
            value !== value
    }

    public hasValue(value: any): boolean {
        return !this.isEmpty(value)
    }

    public hasProperty(object: object, ...properties: string[]): boolean {
        let target = object
        for (let arg in properties) {
            let prop = properties[arg]
            if (!object.hasOwnProperty(prop)) return false

            target = target[prop]
            if (this.isUndefined(target)) return false
        }

        return true
    }

    public isInArray<T>(value: T, array: Array<T>): boolean {
        return !!~array.indexOf(value)
    }

    public newGuid(): string {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, c => {
            let r = Math.random() * 16 | 0
            let v = c === 'x' ? r : (r & 0x3 | 0x8)
            return v.toString(16)
        })
    }

    supplant(template: string, values: object) {
        return template.replace(/\{([^{}]*)\}/g, (a, b): string => {
            let r = values[b]
            let isStrOrNr = typeof r === 'string' || typeof r === 'number'

            return isStrOrNr ? r.toString() : a
        })
    }
}

export default new Utils()
