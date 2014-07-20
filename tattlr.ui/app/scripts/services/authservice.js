'use strict';

angular.module('tattlrApp')
  .factory('AuthService', function ($http) {

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

        this.setAuthHeader(accessToken);

        return this.getUser();
      },
      setAuthHeader: function(accessToken) {
        $http.defaults.headers.common.Authorization = 'Bearer ' + accessToken;
      }
    };
  });
