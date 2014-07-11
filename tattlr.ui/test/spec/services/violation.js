'use strict';

describe('Service: Violation', function () {

  // load the service's module
  beforeEach(module('tattlrApp'));

  // instantiate service
  var Violation;
  beforeEach(inject(function (_Violation_) {
    Violation = _Violation_;
  }));

  it('should do something', function () {
    expect(!!Violation).toBe(true);
  });

});
