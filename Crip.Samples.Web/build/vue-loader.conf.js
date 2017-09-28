var utils = require('./utils')
var config = require('../config')

var isProduction = process.env.NODE_ENV === 'production'
var sourceMap = isProduction
    ? config.build.productionSourceMap
    : config.dev.cssSourceMap

module.exports = {
    loaders: utils.cssLoaders({
        sourceMap,
        extract: isProduction
    }),
    esModule: true,
}
