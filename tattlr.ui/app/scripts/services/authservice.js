'use strict';

angular.module('tattlrApp')
  .factory('AuthService', function ($http) {

    // var url = event.url;
    //
    // if(url.indexOf('access_token=') !== -1) {
    //     //var hash = window.location.hash.substring(1); //Puts hash in variable, and removes the # character
    //     //alert (hash);
    //
    //     var urlSplit = url.split('=');
    //     var tokenSplit = urlSplit[1].split('&');
    //
    //     var token = tokenSplit[0];
    //
    //     localStorage.setItem('tattlrToken', token);
    //
    //     console.log(token);
    //
    //     var violationForm = Ext.create('Tattlr.view.ViolationForm');
    //
    //
    //     main.setActiveItem(violationForm);
    //
    //     ref.close();
    //
    // }

    var baseUrl = 'http://tattlr.azurewebsites.net';

    var user = {
        username: null,
        accessToken: null,
        email: null,
        provider: null
      };

    return {
      getAuthProviders: function() {
        return $http.get(baseUrl+'/api/account/ExternalLogins?returnUrl=/signin', {cache: true});
      },
      getUserInfo: function (token) {
        return $http.get(baseUrl+'/api/account/userinfo', {headers: {'Authorization': 'Bearer '+token}});
      },
      registerExternal: function(token, values) {
        console.log(values);
        return $http.post(baseUrl+'/api/Account/RegisterExternal', values, {headers: {'Authorization': 'Bearer '+token, 'Content-Type': 'application/json'}});
      },
      getUser: function() {
        return user;
      },
      setUser: function(accessToken, userValues) {
        user.username = userValues.UserName;
        user.accessToken = accessToken;
        user.email = userValues.Email;
        user.provider = userValues.LoginProvider;

        return this.getUser();
      }
    };
  });
