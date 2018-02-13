module.exports = {
  lintOnSave: true,
  baseUrl: "/dist/",
  devServer: {
    proxy: "http://localhost:13162",
  },
}
