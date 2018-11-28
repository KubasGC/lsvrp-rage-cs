const path = require("path");
const CopyWebpackPlugin = require("copy-webpack-plugin");
var webpack = require("webpack");

module.exports = {
  entry: "./index.ts",
  plugins: [
    new CopyWebpackPlugin([{
      from: "./LSVRP",
          to: "E:/LSVRPRAGE/client_packages/LSVRP" // Twoj output dir
    }], {
      force: true
    })
  ],
  module: {
    rules: [{
      test: /\.ts?$/,
      use: "ts-loader",
      exclude: /node_modules/
    }]
  },
  watch: true,
  resolve: {
    extensions: [".ts", ".js", "html", "css"]
  },
  output: {
    filename: "index.js",
      path: path.resolve(__dirname, "E:/LSVRPRAGE/client_packages") // Twoj output dir
  },
};