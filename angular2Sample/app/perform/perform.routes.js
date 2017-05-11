"use strict";
var perform_component_1 = require("./perform.component");
var employee_component_1 = require("./employee/employee.component");
exports.routes = [
    { path: '', children: [
            { path: '', component: perform_component_1.PerformComponent },
            { path: 'employee', component: employee_component_1.EmployeeComponent }
        ] },
];
//# sourceMappingURL=perform.routes.js.map