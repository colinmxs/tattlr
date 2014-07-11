'use strict';

angular.module('tattlrApp')
  .controller('SigninCtrl', function ($rootScope, $scope, $location, AuthService) {

    var url = $location.url();

    if(url.indexOf('access_token=') !== -1) {
        //var hash = window.location.hash.substring(1); //Puts hash in variable, and removes the # character
        //alert (hash);

      var urlSplit = url.split('=');
      var tokenSplit = urlSplit[1].split('&');

      var token = tokenSplit[0];

      //console.log(token);

      AuthService.getUserInfo(token).then(function(result) {
        var user = result.data;

        if(user.HasRegistered) {
          // get user data and set it to the AuthService
          var registeredUser = AuthService.setUser(token, user);
          localStorage.setItem('user', registeredUser);
          $rootScope.user = registeredUser;
          console.log($rootScope.user);


        } else {
          // User needs to register in our DB
          // TODO: replace hard coded Email with user.Email when Colin fixes.
          AuthService.registerExternal(token, {"Email": "philbot5000@gmail.com"}).then(function(result) {

            console.log(result);
            if(result.status === 200) {
              AuthService.getAuthProviders().then(function(result) {
                var providers = result.data
                console.log(providers);
                var index = providers.indexOf(user.LoginProvider);

                if(index !== -1) {
                  // check to ensure Provider is listed.
                  var providerUrl = providers[index].Url;
                  console.log(providerUrl);
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
