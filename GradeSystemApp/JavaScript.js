var count = "1";
var i = 0;
function addRow(in_tbl_name) {
  
    var status = validateMinMaxGrade(i);
    if (status) { 
        document.getElementById("addButton" + i).style.visibility = "hidden"
        i++
        var tbody = document.getElementById(in_tbl_name).getElementsByTagName("TBODY")[0];

        // create row
        var row = document.createElement("TR");

        var td1 = document.createElement("TD")
        var strHtml2 = "<input type=\"number\" id=\"min" + i + "\"" + " name=\"minInput\" />";
        td1.innerHTML = strHtml2.replace(/!count!/g, count);

        var td2 = document.createElement("TD")
        var strHtml3 = "<input type=\"number\" id=\"max"+i+"\""+" name=\"maxInput\" />";
        td2.innerHTML = strHtml3.replace(/!count!/g, count);

        var td3 = document.createElement("TD")
        var strHtml4 = "<input type=\"text\" id=\"grade" + i + "\"" + " name=\"gradeInput\" maxlength=\"3\" />";
        td3.innerHTML = strHtml4.replace(/!count!/g, count);


        var td4 = document.createElement("TD")
        var strHtml5 = "<input type=\"button\" value=\"x\" onclick=\"delRow()\" />";
        td4.innerHTML = strHtml5.replace(/!count!/g, count);


        var td5 = document.createElement("TD")
        var strHtml6 = "<input type=\"button\" id=\"addButton" + i + "\"" + " value=\"+\" onclick=\"addRow('tblPets')\" />";
        td5.innerHTML = strHtml6.replace(/!count!/g, count);

        // append data to row

        row.appendChild(td1);
        row.appendChild(td2);
        row.appendChild(td3);
        row.appendChild(td4);
        row.appendChild(td5);
 
        count = parseInt(count) + 1;

        // add to count variable
        // append row to table

        tbody.appendChild(row);
    }
}

function delRow() {

    var current = window.event.srcElement;
    while ((current = current.parentElement) && current.tagName != "TR");
    current.parentElement.removeChild(current);

}

function validateMinMaxGrade(i) {
    var min = document.getElementById("min"+i).value
    var max = document.getElementById("max"+i).value
    var grade = document.getElementById("grade"+i).value

    var dataStatus = document.getElementById("data_status")

    if (min == "" || max == "" || grade == "") { 
        dataStatus.innerHTML = "All field are required"
        return false
    }

    if (Number(max) < Number(min)) {
        dataStatus.innerHTML = "Maximum Mark should be greater than Minimum Mark"
        return false
    }
    dataStatus.innerHTML = ""
    return true
}