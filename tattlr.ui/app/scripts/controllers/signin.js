'use strict';

angular.module('tattlrApp')
  .controller('SigninCtrl', function ($rootScope, $scope, $location, AuthService, $http) {

    var url = $location.url();

    if(url.indexOf('access_token=') !== -1) {
        //var hash = window.location.hash.substring(1); //Puts hash in variable, and removes the # character

      var urlSplit = url.split('=');
      var tokenSplit = urlSplit[1].split('&');

      var token = tokenSplit[0];

      AuthService.getUserInfo(token).then(function(result) {
        var user = result.data;

        console.log(user);

        if(user.HasRegistered) {
          // get user data and set it to the AuthService
          var registeredUser = AuthService.setUser(token, user);
          localStorage.setItem('user', JSON.stringify(registeredUser));
          $rootScope.user = registeredUser;


        } else {
          // User needs to register in our DB
          // TODO: replace hard coded Email with user.Email when Colin fixes.
          AuthService.registerExternal(token, {"Email": "philbot5000@gmail.com"}).then(function(result) {

            //console.log(result);
            if(result.status === 200) {
              AuthService.getAuthProviders().then(function(result) {
                console.log(result.data)
                var providers = result.data;

                // search Array
                var index = providers.map(function(e) {return e.Name; }).indexOf(user.LoginProvider);

                if(index !== -1) {
                  // check to ensure Provider is listed.
                  var providerUrl = providers[index].Url;
                  console.log(providerUrl);
                  $http.get(providerUrl).then(function(result) {
                    console.log(result);
                  });

                } else {
                  console.log('Error: Something is not right. Provider not found.');
                }



              });


            }

          });

        }

      });
    }
  });
