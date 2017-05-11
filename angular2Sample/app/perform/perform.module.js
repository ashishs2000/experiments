"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var common_1 = require("@angular/common");
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var perform_component_1 = require("./perform.component");
var perform_routes_1 = require("./perform.routes");
var ChildDetailModule = (function () {
    function ChildDetailModule() {
    }
    return ChildDetailModule;
}());
ChildDetailModule.routes = perform_routes_1.routes;
ChildDetailModule = __decorate([
    core_1.NgModule({
        declarations: [
            perform_component_1.PerformComponent,
        ],
        imports: [
            common_1.CommonModule,
            router_1.RouterModule.forChild(perform_routes_1.routes),
        ],
    })
], ChildDetailModule);
exports.ChildDetailModule = ChildDetailModule;
//# sourceMappingURL=perform.module.js.map