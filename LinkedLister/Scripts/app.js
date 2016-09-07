'use strict';

angular.module('linkedlister', ['ngRoute'])
    .config(function($routeProvider) {

        var linkedListConfig = {
            controller: 'LinkedListCtrl',
            templateUrl: 'Content/linkedlist.html'
        }

        $routeProvider
            .when('/', linkedListConfig)
            .otherwise({
                redirectTo: '/'
            });

    })
    .controller('LinkedListCtrl', function LinkedListCtrl($scope, $http) {

        var vm = $scope;

        $scope.listOne = {
             Nodes: [{ Id: '1', NextNodeId: '2', Value: 'greetings' }]
        };
        $scope.listTwo = {
             Nodes: []
        };

        $scope.submitLists = function() {
            var data = [vm.listOne, vm.listTwo];
            var res = $http.post('/api/LinkedList', data);
            res.success(function(data, status, headers, config) {
                $scope.listOne = data[0];
                $scope.listTwo = data[1];
            });
        }

        $scope.addNode = function(list) {
            var node = { Id: '', NextNodeId: '', Value: '' };
            list.Nodes.push(node);
        }

        $scope.removeNode = function(node, list) {
            var index = list.Nodes.indexOf(node);
            list.Nodes.splice(index, 1);
        }

    });