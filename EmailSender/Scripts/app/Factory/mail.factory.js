(function () {
	angular.module('EmailSender').factory('MailService', mail);
	//mail.$inject = ['$resource'];
	function mail() {
        return {
            SendMail: function (EmailModel) {
                $.ajax({
                    type: "POST",
                    url: "Home/SendEmail",
                    data: { email: EmailModel },
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        if (data.Result == true) {
                            alert(data.Message)
                            return data;
                        }
                        else 
                            alert(result.Message)
                    },
                    error: function (errorData) {
                        console.log(errorData)
                        alert(errorData.Message);
                    }
                })
            },
			GetMails: function () {
				var result = null;
				$.ajax({
					type: "GET",
					url: "/Home/GetMails",
					data: {},
					async: false,
					dataType: "json",
					success: function (data) {
						result = data;
					},
					error: function (errorData) {
						alert(errorData);
					}
				})

				return result;
            },

            GetMailsByFilter: function (searchString, searchBy) {
                var result = null;
                $.ajax({
                    type: "GET",
                    url: "/Home/GetMailsByFilter",
                    data: { searchString:searchString,SearchBy: searchBy},
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        if (data.Result) {
                            result = data.Mails;
                        } else {
                            alert(data.Message)
                        }
                        
                    },
                    error: function (errorData) {
                        alert(errorData);
                    }
                })

                return result;
            }
		}
	}
})();