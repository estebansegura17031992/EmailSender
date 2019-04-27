(function(){
    angular.module("EmailSender").controller("HomeController", HomeController);
    HomeController.$inject = ["$scope","mail"];
	function HomeController($scope, mail) {
        $scope.sendEmail = function () {
            console.log($scope.Email);
        }
	}
})();