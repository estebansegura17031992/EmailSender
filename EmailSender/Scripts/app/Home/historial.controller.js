(function () {
    angular.module("EmailSender").controller("HistorialController", HistorialController);
    HistorialController.$inject = ["$scope", "MailService"];
    function HistorialController($scope, MailService) {
       $scope.mails = MailService.GetMails();
    }
})();