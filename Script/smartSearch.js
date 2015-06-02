'use strict';

var app = angular.module('SmartSearch', ['ngSanitize', 'ui.select']);

/**
 * AngularJS default filter with the following expression:
 * "person in people | filter: {name: $select.search, age: $select.search}"
 * performs a AND between 'name: $select.search' and 'age: $select.search'.
 * We want to perform a OR.
 */
app.filter('propsFilter', function() {
  return function(items, props) {
    var out = [];

    if (angular.isArray(items)) {
      items.forEach(function(item) {
        var itemMatches = false;

        var keys = Object.keys(props);
        for (var i = 0; i < keys.length; i++) {
          var prop = keys[i];
          var text = props[prop].toLowerCase();
          if (item[prop].toString().toLowerCase().indexOf(text) !== -1) {
            itemMatches = true;
            break;
          }
        }

        if (itemMatches) {
          out.push(item);
        }
      });
    } else {
      // Let the output be the input untouched
      out = items;
    }

    return out;
  };
});

app.controller('SmartSearchCtrl', function($scope, $http, $timeout) {

    $scope.depts;
    $scope.dept = {};

    $scope.loadDepartments = function() {
        $.ajax({
            type: "POST",
            url: "../Webservices/SmartSearchService.asmx/GetAllDepartments",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(response) {
                var depts = response.d;

                $scope.depts = depts;

                $('#output').empty();
                var out = "";

            },
            failure: function(msg) {
                $('#output').text(msg);
            }
        });
    };

    $scope.employees;
    $scope.employee = {};
    $scope.master = {};
    $scope.loadEmployees = function(id) {

        var params = { id: id };

        console.info(params);
        $.ajax({
            type: "POST",
            url: "../Webservices/SmartSearchService.asmx/GetEmployeeByDept",
            data: JSON.stringify(params),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(response) {
                var employees = response.d;

                $scope.employees = employees;

                $('#output').empty();
                var out = "";

            },
            failure: function(msg) {
                $('#output').text(msg);
            }
        });
    };

    $scope.setHiddenWithOrg1 = function (item)
    {     
        document.getElementById('ctl00_ContentPlaceHolder1_Project_Inbox1_OrgDesc').value = item.name;
        document.getElementById('ctl00_ContentPlaceHolder1_Project_Inbox1_OrgID').value = item.id;
      
    };

    $scope.setHiddenWithOrg2 = function (item) {
        document.getElementById('ctl00_ContentPlaceHolder1_Inbox_Search1_OrgDesc').value = item.name;
        document.getElementById('ctl00_ContentPlaceHolder1_Inbox_Search1_OrgID').value = item.id;

    };

    $scope.setHiddenWithOrg3 = function (item) {
        document.getElementById('ctl00_ContentPlaceHolder1_Project_Outbox1_OrgDesc').value = item.name;
        document.getElementById('ctl00_ContentPlaceHolder1_Project_Outbox1_OrgID').value = item.id;

    };

    $scope.setHiddenWithOrg4 = function (item) {
        document.getElementById('ctl00_ContentPlaceHolder1_Outbox_Search1_OrgDesc').value = item.name;
        document.getElementById('ctl00_ContentPlaceHolder1_Outbox_Search1_OrgID').value = item.id;

    };


    $scope.someFunction = function(item) 
    {
        var x = document.getElementById('OrgDesc').value;
        //console.info(x);
    };
    $scope.loadInboxFromEmpID = function(item) {

    $scope.loadInbox(item.id);

    };
    
    
    $scope.organizations;

    $scope.organization = {};
    $scope.type=0;
    $scope.loadOrganization = function ()
    {
        if($scope.type==1)
        $scope.initialSelectedOrganization = document.getElementById('ctl00_ContentPlaceHolder1_Project_Inbox1_OrgDesc').value;;
        if($scope.type==2)
        $scope.initialSelectedOrganization1 = document.getElementById('ctl00_ContentPlaceHolder1_Project_Outbox1_OrgDesc').value;
        if($scope.type==3)
        $scope.initialSelectedOrganization2 = document.getElementById('ctl00_ContentPlaceHolder1_Outbox_Search1_OrgDesc').value;
        if($scope.type==4)
            $scope.initialSelectedOrganization3 = document.getElementById('ctl00_ContentPlaceHolder1_Inbox_Search1_OrgDesc').value;
        console.info($scope.type);
        //if (type==1) {
        //    $scope.initialSelectedOrganization = document.getElementById('ctl00_ContentPlaceHolder1_Project_Inbox1_OrgDesc').value;
        //    console.info("here1");
        //}
        //else if (type==2) {
        //    $scope.initialSelectedOrganization1 = document.getElementById('ctl00_ContentPlaceHolder1_Project_Outbox1_OrgDesc').value;
        //    console.info("here11");
        //}
        //else if (type == 3)
        //{
        //    $scope.initialSelectedOrganization2 = document.getElementById('ctl00_ContentPlaceHolder1_Outbox_Search1_OrgDesc').value;
        //}
        //else if(type==4)
        //    $scope.initialSelectedOrganization3 = document.getElementById('ctl00_ContentPlaceHolder1_Inbox_Search1_OrgDesc').value;
        //    $.ajax({
                type: "POST",
                url: "../Webservices/SmartSearchService.asmx/GetAllOrgByFoundId",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var organizations = response.d;
                    $scope.organizations = organizations;
                    //console.info("success");
                    $('#output').empty();
                    var out = "";
                },
                failure: function (msg) {
                    $('#output').text(msg);
                }
            });

         
    };

   

    function indexOfExt(list, item)
    {
        var len = list.length;

        for (var i = 0; i < len; i++)
        {
            var keys = Object.keys(list[i]);
            var flg = false;
            for (var j = 0; j < keys.length; j++)
            {
                var value = list[i][keys[j]];
                //console.info(value);
                //console.info(item[keys[j]]);
                if (item[keys[j]] === value)
                {
                    flg = true;
                }
            }
            if (flg == true)
            {
                return i;
            }
        }
        return -1;
    }




    $scope.inboxItems;
    $scope.inboxItem = {};

    $scope.loadInbox = function(id) {

        var params = { id: id };

        console.info(params);
        $.ajax({
            type: "POST",
            url: "../Webservices/SmartSearchService.asmx/GetAllInboxByEmpId",
            data: JSON.stringify(params),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(response) {
                var inboxItems = response.d;

                $scope.inboxItems = inboxItems;

                $('#output').empty();
                var out = "";

            },
            failure: function(msg) {
                $('#output').text(msg);
            }
        });
    };
});
