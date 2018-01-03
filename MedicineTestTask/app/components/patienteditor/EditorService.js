(function () {
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
                };
                this.GetSortedPatients = function (from, to, fieldName, sortDirection) {                    
                    return GetSortedPatients(from, to, fieldName, sortDirection);
                };

                function GetSortedPatients(from, to, fieldName, sortDirection)
                {
                    return $http({
                        url: apiUrl + 'GetSorted',
                        cache: false,
                        method: "get",
                        params: { from, to, fieldName, sortDirection }
                    });
                }
                function GetSortedPatientsFake(from, to)
                {
                    return new Promise(function (resolve) {
                        var list = [];
                        var now = new Date();
                        var totalRecords = 30;
                        to = to > totalRecords ? totalRecords : to;                        
                        for (var i = from; i <= to; i++) {                            
                            var patient = { FirstName: 'John', SecondName: i, BirthDate: new Date(now.getFullYear(), now.getMonth(), i) };
                            list.push(patient);
                        }
                        resolve({ data: { Items: list, TotalCount: otalRecords } });
                    });                    
                }
            }
        ]);    
})();
