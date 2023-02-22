
function Update() {
    //ClearAll();
    $('#btnmodeledit').trigger('click');
}


//function ClearAll() {
//    $('#FirstName').val('');
//    $('#LastName').val('');
//    $('#DOB').val('');
//    $('#Gender').val('');
//    $('#DeptId').val('');
//    $('#DesignationId').val('');
//    $('#Salary').val('');
//    $('#SkillName').val('');
//}


function Save() {
    var firstname = $('#FirstName').val();
    var lastname = $('#LastName').val();
    var dob = $('#DOB').val();
    var gender = $('#Gender').val();
    var deptid = $('#DeptId').val();
    var desgid = $('#DesignationId').val();
    var salary = $('#Salary').val();
    //var skill =  $('#SkillName').val(); //$('#chk').val(); //
    var val = [];
    $(':checkbox:checked').each(function (i) {
        val[i] = Number($(this).val());
    });

    var skill = val.join(',');
    var empdata = new Object();

    if (!firstname) {
        alert('FirstName Required !!!');
        return;
    }

    if (!lastname) {
        alert('lastName Required !!!');
        return;
    }




    empdata.firstname = firstname;
    empdata.lastname = lastname;
    empdata.dob = dob;
    empdata.gender = gender;
    empdata.deptid = deptid;
    empdata.DesignationId = desgid;
    empdata.salary = salary;
    empdata.skills = skill;

    let p_employee = empdata;// $('test').serialize();

    $.ajax({
        type: 'post',
        url: '/Employee/CreateEmploye',
        data: p_employee,
        traditional: true,
        success: function (data) {
            if (data) {
                console.log(data);
                alert('Saved Successfully !!')
                //$('#tbl_id').load('/Employee/Index');
                //window.load('/Employee/Index');
                //window.location.href="/Employee/Index"; //~/Views/Employee/Index
                $.get('/Employee/Index', function (data) {
                    $("body").html(data)
                });
            } else {
                alert('failed !!')
            }
        }
    });
}