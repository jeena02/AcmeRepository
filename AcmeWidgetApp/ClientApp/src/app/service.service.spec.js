"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var service_service_1 = require("./service.service");
describe('ServiceService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(service_service_1.default);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=service.service.spec.js.map