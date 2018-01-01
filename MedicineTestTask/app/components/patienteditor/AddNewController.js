(function () {
    'use strict';

    angular
        .module('app')
        .controller('AddNewController', ['$scope', '$state', 'EditorService',
            function ($scope, $state, EditorService) {

                $scope.patient = {
                    FirstName: '', SecondName:'', BirthDate: new Date()
                };

                $scope.formInstance = {};
                $scope.initializedHandler = function (e) {
                    $scope.formInstance = e.component;
                }
                var notificationShowTimeout = 3000;
                $scope.savePatient = function () {
                    var result = $scope.formInstance.validate();
                    if (!result.isValid) {
                        DevExpress.ui.notify("The form was filled incorrect.", "warning", notificationShowTimeout);
                    }                                                            
                    EditorService.SaveNew($scope.patient)
                        .then(function (responce) {
                            DevExpress.ui.notify("Saving was succeed.", "success", notificationShowTimeout);
                            $state.go($scope.tabs[0].route);
                    })
                        .catch(function () {
                            DevExpress.ui.notify("Error happened during the request processing.", "error", notificationShowTimeout);
                    });
                };
                var maxNameLength = 150;
                var maxNameLengthMessage = "A name hasn't to have a length more than " + maxNameLength + " symbols";
                $scope.widgetOptions = [
                    {
                        dataField: 'FirstName',
                        validationRules: [
                            {
                                type: 'required',
                                message: 'Fill in first name'},
                            {
                                type: 'stringLength',
                                max: maxNameLength,
                                message: maxNameLengthMessage
                            }
                        ]
                    },
                    {
                        dataField: 'SecondName',
                        validationRules: [
                            {
                                type: 'required',
                                message: 'Fill in second name'
                            },
                            {
                                type: 'stringLength',
                                max: maxNameLength,
                                message: maxNameLengthMessage
                            }
                        ]
                    },
                    {
                        dataField: 'BirthDate',
                        validationRules: [
                            { type: 'required' },
                            {
                                type: 'range',
                                min: new Date(1800, 1, 1),
                                max: new Date,
                                message: 'The birth date must be between 01.01.1800 and today date'
                            }
                        ]
                    }
                ];
            }
        ]);
})();
