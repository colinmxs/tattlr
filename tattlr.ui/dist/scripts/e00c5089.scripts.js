"use strict";angular.module("tattlrApp",["ngResource","ngSanitize","ngRoute","ui.bootstrap"]).config(["$routeProvider","$locationProvider",function(a,b){a.when("/",{templateUrl:"views/main.html",controller:"MainCtrl"}).when("/about",{templateUrl:"views/about.html",controller:"AboutCtrl"}),b.html5Mode(!0)}]),angular.module("tattlrApp").controller("MainCtrl",["$scope",function(a){a.awesomeThings=["HTML5 Boilerplate","AngularJS","Karma"]}]),angular.module("tattlrApp").controller("MenuCtrl",["$scope","$modal",function(a,b){a.openLoginModal=function(){b.open({templateUrl:"views/login.html",controller:"LoginCtrl"})}}]),angular.module("tattlrApp").controller("AboutCtrl",["$scope",function(a){a.awesomeThings=["HTML5 Boilerplate","AngularJS","Karma"]}]),angular.module("tattlrApp").factory("AuthService",["$http",function(a){var b="http://tattlr.azurewebsites.net",c={username:null,accessToken:null,email:null,provider:null};return{getAuthProviders:function(){return a.get(b+"/api/account/ExternalLogins?returnUrl=/")},getUserInfo:function(){return a.get(b+"/api/account/userinfo")},registerExternal:function(c){return a.post(b+"/api/Account/RegisterExternal",c)},getUser:function(){return c}}}]),angular.module("tattlrApp").controller("LoginCtrl",["$scope","AuthService","$modalInstance",function(a,b,c){b.getAuthProviders().then(function(b){a.authProviders=b.data,console.log(a.authProviders)}).then(function(){b.getUser()}),a.ok=function(){c.close(a.selected.item)},a.cancel=function(){c.dismiss("cancel")}}]);