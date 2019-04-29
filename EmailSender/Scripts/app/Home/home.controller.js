(function(){
    angular.module("EmailSender").controller("HomeController", HomeController);
    HomeController.$inject = ["$scope","MailService"];
    function HomeController($scope, MailService) {
        $scope.sendEmail = function () {
            
            var EmailModel = {
                Email: $scope.Email,
                Subject: $scope.Subject,
	            Body: $scope.Body
            }
            
            MailService.SendMail(EmailModel);
        }
	}
})();