
var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {
        $scope.InsertData = function () {
            var Action = document.getElementById("btnSave").getAttribute("value");
            if (Action == "Submit") {
                $scope.Product = {};
                $scope.Product.Name = $scope.ProName;
                $scope.Product.Model = $scope.ProModel;
                $scope.Product.Category = $scope.ProCategory;
                $scope.Product.Price = $scope.ProPrice;
                $http({
                    method: "post",
                    url: "http://localhost:53703/Product/Insert_Product",
                    datatype: "json",
                    data: JSON.stringify($scope.Product)
                }).then(function (response) {
                    alert(response.data);
                    $scope.GetAllData();
                    $scope.ProName = "";
                    $scope.ProModel = "";
                    $scope.ProCategory = "";
                    $scope.ProPrice = "";
                })
            } else {
                $scope.Product = {};
                $scope.Product.Name = $scope.ProName;
                $scope.Product.Model = $scope.ProModel;
                $scope.Product.Category = $scope.ProCategory;
                $scope.Product.Price = $scope.ProPrice;
                $scope.Product.ID = document.getElementById("ID_").value;
                $http({
                    method: "post",
                    url: "http://localhost:53703/Product/Update_Product",
                    datatype: "json",
                    data: JSON.stringify($scope.Product)
                }).then(function (response) {
                    alert(response.data);
                    $scope.GetAllData();
                    $scope.ProName = "";
                    $scope.ProModel = "";
                    $scope.ProCategory = "";
                    $scope.ProPrice = "";
                    document.getElementById("btnSave").setAttribute("value", "Submit");
                    document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                    document.getElementById("spn").innerHTML = "Add New Product";
                })
            }
        }
        $scope.GetAllData = function () {
            $http({
                method: "get",
                url: "http://localhost:53703/Product/Get_AllProducts"
            }).then(function (response) {
                $scope.ProductTable = response.data;
            }, function () {
                alert("Error Occur");
            })
        };
        $scope.DeletePro = function (Pro) {
            $http({
                method: "post",
                url: "http://localhost:53703/Product/Delete_Product",
                datatype: "json",
                data: JSON.stringify(Pro)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
            })
        };
        $scope.UpdatePro = function (Pro) {
            document.getElementById("ID_").value = Pro.ID;
            $scope.Product = {};
            $scope.Product.Name = $scope.ProName;
            $scope.Product.Model = $scope.ProModel;
            $scope.Product.Category = $scope.ProCategory;
            $scope.Product.Price = $scope.ProPrice;
            document.getElementById("btnSave").setAttribute("value", "Update");
            document.getElementById("btnSave").style.backgroundColor = "Yellow";
            document.getElementById("spn").innerHTML = "Update Product Information";
        }
    })
