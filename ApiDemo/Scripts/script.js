$(function () {
    $('#btnLoad').click(function () {
        $.ajax({
            url: 'http://localhost:52236/api/departments',
            method: 'GET',
            success: function (deptList) {
                $('#msg').html(deptList.length + " departments found");
                deptList.forEach(function (dept) {
                    var row = "<li><a href='#'>" + dept.Name + "</a></li>";
                    $('#dlist').append(row);
                });
                
            }
        });
    });
});