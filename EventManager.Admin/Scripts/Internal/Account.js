var app = angular.module("Homeapp", ['ui.bootstrap']);

app.controller("HomeController", function ($scope, $http) {
	$scope.maxsize = 100;
	$scope.totalCount = 10;
	$scope.pageIndex = 1;
	$scope.pageSize = 100;
	$scope.numPages = 1;
	$scope.employees;
	$scope.employee = {};
	$scope.searchCity=5 ;
	$scope.cities = [
		{ CityId: "0", Name: "Chọn Thành Phố", EvtHappened: "false" },
		{ CityId: "1", Name: "Cần Thơ", EvtHappened: "false" },
		{ CityId: "2", Name: "Quy Nhơn", EvtHappened: "false" },
		{ CityId: "3", Name: "Đà Nẵng", EvtHappened: "false" },
		{ CityId: "4", Name: "Nha Trang", EvtHappened: "false" },
		{ CityId: "5", Name: "TP.HCM", EvtHappened: "false" },
		{ CityId: "6", Name: "Buôn Ma Thuột", EvtHappened: "false" },
		{ CityId: "7", Name: "Phan Thiết", EvtHappened: "false" }
	];

	

	$scope.accountlist = function () {
		
		$http.get("/api/AccountApi/Get_AllEmployee?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize + "&cityId=" + $scope.searchCity).then(function (response) {
			debugger;
			$scope.employees = response.data.Result;
			$scope.totalCount = response.data.TotalCount;
			$scope.numPages = response.data.TotalCount / $scope.pageSize;
		}, function (error) {
			alert('failed');
		});
	}

	$scope.orderByMe = function (x) {
		$scope.myOrderBy = x;
	}

	$scope.pagechanged = function () {
		$scope.accountlist();
	}

	$scope.changePageSize = function () {
		$scope.pageIndex = 1;
		
		$scope.accountlist();
	}

	$scope.criteriachanged = function () {
	
		$scope.accountlist();
	}

	$scope.setSelectedCity = function (val1, val2) {
	
		return (val1 == val2 ? 'true' : 'false');
	}

	$scope.accountlist();

	$scope.getForUpdate = function (Employee) {
		
		//	$scope.AccountID = Employee.id;

		//$scope.employee.UserName = Employee.UserName;
		//$scope.employee.Address = Employee.Address;
		//$scope.employee.FirstName = Employee.FirstName;
		//$scope.employee.LastName = Employee.LastName;
		
		$scope.BirthDate = Employee.BirthDate;
		$scope.PhoneNumber = Employee.PhoneNumber;
		$scope.DeviceId = Employee.DeviceId;
		$scope.QRCode = Employee.QRCode;
	}
});

 
var app1  = angular.module('myModule', ['ui.bootstrap']);
app1.controller('myCtrl', ['$scope', function ($scope) {
	$scope.maxSize = 5;
	$scope.currentPage = 1;
	$scope.totalPages = 20;
 
	$scope.pageChanged = function () {
		// operation to perform on page changed
		console.log("Hi I am on ",($scope.currentPage-1),"page")
	};
}])
 