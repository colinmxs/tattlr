"use strict";angular.module("tattlrApp",["ngResource","ngSanitize","ngRoute","ui.bootstrap"]).config(["$routeProvider","$locationProvider",function(a,b){a.when("/",{templateUrl:"views/main.html",controller:"MainCtrl"}).when("/about",{templateUrl:"views/about.html",controller:"AboutCtrl"}).when("/signin",{templateUrl:"views/signin.html",controller:"SigninCtrl"}),b.html5Mode(!0)}]).run(["$rootScope","$http",function(a,b){var c=localStorage.getItem("user");c?(a.user=c,b.defaults.headers.common.Authorization="Bearer "+c.accessToken):(console.log("user not found."),a.user=null)}]),angular.module("tattlrApp").controller("MainCtrl",["$scope",function(a){a.awesomeThings=["HTML5 Boilerplate","AngularJS","Karma"]}]),angular.module("tattlrApp").controller("MenuCtrl",["$rootScope","$scope","$modal",function(a,b,c){console.log(a.user),b.loggedIn=a.user?!0:!1,b.openLoginModal=function(){c.open({templateUrl:"views/login.html",controller:"LoginCtrl"})}}]),angular.module("tattlrApp").controller("AboutCtrl",["$scope",function(a){a.awesomeThings=["HTML5 Boilerplate","AngularJS","Karma"]}]),angular.module("tattlrApp").factory("AuthService",["$http",function(a){var b="http://tattlr.azurewebsites.net",c={username:null,accessToken:null,email:null,provider:null};return{getAuthProviders:function(){return a.get(b+"/api/account/ExternalLogins?returnUrl=/signin",{cache:!0})},getUserInfo:function(c){return a.get(b+"/api/account/userinfo",{headers:{Authorization:"Bearer "+c}})},registerExternal:function(c,d){return console.log(d),a.post(b+"/api/Account/RegisterExternal",d,{headers:{Authorization:"Bearer "+c,"Content-Type":"application/json"}})},getUser:function(){return c},setUser:function(a,b){return c.username=b.UserName,c.accessToken=a,c.email=b.Email,c.provider=b.LoginProvider,this.getUser()}}}]),angular.module("tattlrApp").controller("LoginCtrl",["$scope","AuthService","$modalInstance","$window",function(a,b,c,d){b.getAuthProviders().then(function(b){a.authProviders=b.data,console.log(a.authProviders)}).then(function(){b.getUser()}),a.goTo=function(a){d.location=a},a.ok=function(){},a.cancel=function(){c.dismiss("cancel")}}]),angular.module("tattlrApp").controller("SigninCtrl",["$rootScope","$scope","$location","AuthService",function(a,b,c,d){var e=c.url();if(-1!==e.indexOf("access_token=")){var f=e.split("="),g=f[1].split("&"),h=g[0];d.getUserInfo(h).then(function(b){var c=b.data;if(c.HasRegistered){var e=d.setUser(h,c);localStorage.setItem("user",e),a.user=e,console.log(a.user)}else d.registerExternal(h,{Email:"philbot5000@gmail.com"}).then(function(a){console.log(a),200===a.status&&d.getAuthProviders().then(function(a){var b=a.data;console.log(b);var d=b.indexOf(c.LoginProvider);if(-1!==d){var e=b[d].Url;console.log(e)}else console.log("Error: Something is not right. Provider not found.")})})})}}]),angular.module("tattlrApp").factory("ViolationDetailService",function(){return{getViolation:function(){return this.violation},setViolation:function(a){this.violation=a}}}),angular.module("tattlrApp").factory("ViolationService",["$http",function(a){return{deleteViolation:function(b){return a.delete("http://tattlr.azurewebsites.net/api/report/"+b)},getViolations:function(){return a.get("http://tattlr.azurewebsites.net/api/report/")}}}]);