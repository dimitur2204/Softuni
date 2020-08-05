"use strict";
exports.__esModule = true;
/// <reference path="../node_modules/handlebars/types/index.d.ts" />
var hbs = require("handlebars");
var template = hbs.template("<h1>Hello</h2>");
var html = template({});
var div = document.querySelector('#main');
if (div) {
    div.innerHTML += html;
}
