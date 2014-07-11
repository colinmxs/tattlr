'use strict';

angular.module('tattlrApp')
  .controller('SigninCtrl', function ($scope, $location, AuthService) {

    var url = $location.url();

    if(url.indexOf('access_token=') !== -1) {
        //var hash = window.location.hash.substring(1); //Puts hash in variable, and removes the # character
        //alert (hash);

      var urlSplit = url.split('=');
      var tokenSplit = urlSplit[1].split('&');

      var token = tokenSplit[0];

      localStorage.setItem('tattlrToken', token);

      console.log(token);

      AuthService.getUserInfo(token).then(function(result) {

        if(result.data.hasRegistered) {

          // get user data and s

        } else {
          // User needs to register in our DB
          AuthService.registerExternal(token, result.data.Email).then(function(result) {

            console.log(result);


          });

        }

      });


        // var violationForm = Ext.create('Tattlr.view.ViolationForm');
        //
        //
        // main.setActiveItem(violationForm);
        //
        // ref.close();

    }
  });
