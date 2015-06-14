
$(function () {
     
   

    //initialize the wizard
    $('#wizard').smartWizard({
        onLeaveStep: onLeaveStepCallback,
        onFinish: onFinishCallback,        
    });

    //init the sync area
    steps.Init();


    //initialize the table
    loadDataTable.Init();
    
    //auto adjust the content
    $('#wizard').smartWizard("fixHeight");

    //onLeavestep function describe each step
    function onLeaveStepCallback(obj, context) {
 
        //step 1 checking
        if (context.fromStep == 1) {
            if (!$("#step1Form").valid()) {
                return false;
            }
        }

        //step 2 checking
        if (context.fromStep == 2) {          
            if ($("#PrimaryUser_FirstName").val() != "" && $("#PrimaryUser_LastName").val() != "") {
                $('#wizard').smartWizard('hideError', { stepnum: 2, iserror: false });
                $('#wizard').smartWizard('hideMessage');
                return true;
            }
            else {
                $('#wizard').smartWizard('setError', { stepnum: 2, iserror: true });
                $('#wizard').smartWizard('showMessage', 'The primary user information is mandatory.');
                return false;
            }
        }
         
        //on step 4 to save the result
        if (context.toStep == 5) {
             
            //action
            var action = "/SmartWizard/SaveSteps/";

            //params
            var params = GetParamsData($('#wizard'));

            //ajax save result
            AjaxUtils.ajaxPostBusy(action, params, function (result) {
           

                AjaxUtils.ajaxLoad($("#step-5"), "/Home/Step5Summary/", function () {
                    //initialize the table
                    loadDataTable.Init();

                    //auto adjust the content
                    //$("#step-5")
                    $('#wizard').smartWizard("fixHeight");

                });
               

            }, "Saving...")

         
    }

        

        return true;
    }

    //onFinishCallback to submit the result
    function onFinishCallback(obj) {
        $('#wizard').smartWizard("fixHeight");
    }

   

});

var loadDataTable = {
    Init: function(){

        //initialization datatbale
        $("#userTable").dataTable({
            "aoColumns":[
                { "sTitle":"User name", "sWidth":"auto"},
                { "sTitle":"Email", "sWidth": "auto" },
                { "sTitle":"Address", "sWidth": "auto" },
                { "sTitle":"Contact", "sWidth": "auto" },
            ],
            "bServerSide": false,
            "bFilter": true,
            "sPaginationType": "full_numbers",
            "iDisplayLength": 5,
            "sDom": '<"tbl-tools-searchbox"fl<"clear">>,<"tbl_tools hide"TC<"processingMessage"r><"clear">>,<"table_content"t>,<"widget-bottom"p<"clear">>',
            "fnDrawCallback": function (oSettings) {
                //auto adjust the content
                //$('#wizard').smartWizard("fixHeight");
            }
        });

        //hide the entries
        $("#userTable_length").hide();
    }

};

//define the process of each step
var steps = {
    Init: function () {

        //keep the select value sync
        function keepDropdownSync(selectorSelect, selectorInput) {
            $(selectorSelect).click(function () {               
                $(selectorInput).html($(this).find("option:selected").text());
            });
        }

        //keep the text/dropdown sync
        function keepSync(selector, selectorSysc) {
            $(selector).change(function () {
                $(selectorSysc).html($(this).val());
            });
            $(selectorSysc).change(function () {
                $(selector).val($(this).val());
            });
        }

        //keep the radio button sync
        function keepRadioSync(selectors, selectorSysc) {
            //console.log(selectors+ " :  " +$(selectors).val());
            var selected = "input[name='"+selectors+"']";
            $(selected).click(function () {
                var status = selected + ":checked";
                $(selectorSysc).html($(status).val());                 
            });
        }
         
        //keep the checkbox sync
        function keeyCheckboxSync(selectors, selectorSysc) {
            $(selectors).on('click', function () {
                if ($(selectors).prop("checked")) {
                    $(selectorSysc).html($(selectors).attr("data-display"));
                }

            });
        }

        //Sync step 1
        keepSync("#Organisation_UserName", "#Organisation_UserName_Sync");
        keepDropdownSync("#Organisation_Country", "#Organisation_Country_Sync");
        keepSync("#Organisation_OrganisationName", "#Organisation_OrganisationName_Sync");
        keepSync("#Organisation_Address", "#Organisation_Address_Sync");
        keepSync("#Organisation_Contact", "#Organisation_Contact_Sync");
        
        //Sync step 2
        keepSync("#PrimaryUser_FirstName", "#PrimaryUser_FirstName_Sync");
        keepSync("#PrimaryUser_LastName", "#PrimaryUser_LastName_Sync");
        keepSync("#PrimaryUser_Email", "#PrimaryUser_Email_Sync");
        keepSync("#PrimaryUser_Address", "#PrimaryUser_Address_Sync");
        keepSync("#PrimaryUser_Contact", "#PrimaryUser_Contact_Sync");

        keepSync("#SecondaryUser_FirstName", "#SecondaryUser_FirstName_Sync");
        keepSync("#SecondaryUser_LastName", "#SecondaryUser_LastName_Sync");
        keepSync("#SecondaryUser_Email", "#SecondaryUser_Email_Sync");
        keepSync("#SecondaryUser_Address", "#SecondaryUser_Address_Sync");
        keepSync("#SecondaryUser_Contact", "#SecondaryUser_Contact_Sync");

        //Sync step 3
        keeyCheckboxSync("#Questionnaire_IsJave", "#Questionnaire_IsJave_Sync");
        keeyCheckboxSync("#Questionnaire_IsCSharp", "#Questionnaire_IsCSharp_Sync");
        keeyCheckboxSync("#Questionnaire_IsChinese", "#Questionnaire_IsChinese_Sync");
        keepRadioSync("Questionnaire.FrontendTech", "#Questionnaire_FrontendTech_Sync");
        keepSync("#Questionnaire_HtmlVersion", "#Questionnaire_HtmlVersion_Sync");
        keepRadioSync("Questionnaire.HearFrom", "#Questionnaire_HearFrom_Sync");
        keepSync("#Questionnaire_Comment", "#Questionnaire_Comment_Sync");

         
    }
};

//get all the input elements
var GetParamsData = function (selector, includeNull) {
    var inputs = $(":input", selector);
    var params = {};
    inputs.each(function (index, elem) {
        var value = '';
        var name = $(elem).attr("name");

        if ($(elem).attr("type") == "checkbox") {
            value = $(elem).prop("checked");
        } else if ($(elem).attr("type") == "radio") {
            value = $(elem).filter(":checked").val();
        } else if ($(elem).attr("type") == "hidden") {
            value = (name in params) ? '' : $(elem).val();
        } else {
            value = $(elem).val();
        }
        if (includeNull === true || (value != null && value != '')) {
            params[name] = value;
        }
    });
    //console.log(params);
    return params;
};
