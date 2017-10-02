import { api } from '../../api/index'
import { Status } from '../../models/StatusDetails'

class Api extends api.Base<Status.StatusDetails> {
    public async GetStatus(): Promise<Status.StatusDetails> {
        var result = await this.Find<Status.StatusDetails>('/Status/Index', 0)
        return result
    }
}

export module status {
    export const api = new Api()
}

