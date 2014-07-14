'use strict';

describe('Service: ViolationDetail', function () {

  // load the service's module
  beforeEach(module('tattlrApp'));

  // instantiate service
  var ViolationDetail;
  beforeEach(inject(function (_ViolationDetail_) {
    ViolationDetail = _ViolationDetail_;
  }));

  it('should do something', function () {
    expect(!!ViolationDetail).toBe(true);
  });

});
