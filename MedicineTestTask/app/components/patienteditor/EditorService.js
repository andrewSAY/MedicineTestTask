﻿(function () {
    'use strict';

    angular
        .module('app')
        .service('EditorService', ['$http',
            function ($http) {
                var apiUrl = 'api/Patients/';
                this.SaveNew = function (patient) {
                    return $http({
                        url: apiUrl + 'PostNew',
                        cache: false,
                        method: "post",
                        data: patient
                    });
                }
            }
        ]);    
})();