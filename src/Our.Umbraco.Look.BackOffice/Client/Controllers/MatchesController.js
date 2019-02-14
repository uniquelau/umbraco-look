﻿(function () {
    'use strict';

    // matches controller handles the paging and rendering of collection of matches (from parent scope)
    angular
        .module('umbraco')
        .controller('Look.BackOffice.MatchesController', MatchesController);

    MatchesController.$inject = ['$scope', 'Look.BackOffice.SortService'];

    // this controller will handle paging for more results
    function MatchesController($scope, sortService) {

        var getMatches = $scope.$parent.getMatches; // $scope.$parent.getMatches(sort, skip, take) expected to exist

        getMatches(sortService.sortOn, 0, 2) // sort, skip 0, take all
            .then(function (matches) {
                $scope.matches = matches;
            });

        sortService.onChange(function () {
            $scope.matches = null;
        });

    }

})();