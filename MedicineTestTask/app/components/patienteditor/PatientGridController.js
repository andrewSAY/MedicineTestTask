(function () {
    'use strict';

    angular
        .module('app')
        .controller('PatientGridController', ['$scope','EditorService',
            function ($scope, EditorService) {
                var defaultPageSize = 12;
                var dataStore = new DevExpress.data.CustomStore({
                    load: function (loadOptions) {
                        var from = loadOptions.skip + 1;
                        var to = loadOptions.take == 0 ? defaultPageSize : loadOptions.take + loadOptions.skip;
                        var sortDirection = Patienteditor.global.sortDirection.asc;
                        var sortField = "FirstName";
                        if (loadOptions.sort !== null) {
                            var firstSort = loadOptions.sort[0];
                            if (firstSort.desc)
                                sortDirection = Patienteditor.global.sortDirection.desc;
                            if (firstSort.selector !== null || firstSort.selector !== undefined)
                                sortField = firstSort.selector
                        }

                        return EditorService.GetSortedPatients(from, to, sortField, sortDirection)
                            .then(function (response) {
                                return { data: response.data.Items, totalCount: response.data.TotalCount };
                            });
                    }
                });

                $scope.widgetOptions = {
                    dataSource: {
                        store: dataStore
                    },
                    remoteOperations: {
                        sorting: true,
                        paging: true
                    },
                    paging: {
                        pageSize: defaultPageSize
                    },
                    pager: {
                        showPageSizeSelector: true,
                        allowedPageSizes: [8, 12, 20]
                    },
                    columns: [
                        "FirstName", "SecondName",
                        {
                            dataField: "BirthDate",
                            dataType: "date",
                            format: "MM.dd.yyyy"
                        }
                    ]
                };
            }
        ]);   
})();
