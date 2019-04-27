(function () {
    angular.module("EmailSender").controller("HistorialController", HistorialController);
    HistorialController.$inject = ["$scope", "mail"];
    function HistorialController($scope, mail) {
        console.log("Historial")
    }
})();