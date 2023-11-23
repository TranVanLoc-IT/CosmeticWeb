//
function responseEachSearch(textSearch, dataServer) {
    var results = [];
    var scaleTextSearch = textSearch[0].toUpperCase() + textSearch.substring(1, textSearch.length);
    dataServer.map((data, index) => {
        if (data.tensp.substring(0, scaleTextSearch.length) == scaleTextSearch || data.tensp.includes(scaleTextSearch)) {
            let toHtml = `<li class='list-item '><a href='${document.getElementById('details_link' + data.masp).href}' class='text-primary p-1 text-decoration-none'>${data.tensp}</a></li>`;
            results.push(toHtml);
        }
    })
    var elementDisplay = "";
    results.forEach(res => {
        elementDisplay += res;
    })
    document.querySelector(".hint_result").innerHTML = `
        <ul class='list-group-item list-unstyled w-100' style='z-index: 12'>
            ${elementDisplay}
        </ul>
    `;
}

// Lấy tham chiếu đến toast element
var overTimeSale = new bootstrap.Toast(document.getElementById('informOverSale'));

window.onload = function () {
    const days = document.querySelector(".days");
    const hours = document.querySelector(".hours");
    const minutes = document.querySelector(".minutes");
    const seconds = document.querySelector(".seconds");

    var saleInter = setInterval(run_time_sale, 1000);

    const date_now = new Date();
    const date_end = new Date("2023/11/28, 21:57:00");
    const time_to_end = Math.abs(date_now - date_end);// miliseconds
    if (date_now > date_end) {
        $(document).ready(function () {
            $('.event_sale').css('display', 'none')
        })
        return;
    }

    var getSeconds = Math.floor((time_to_end / 1000) % 60);
    var getMinutes = Math.floor((time_to_end / (1000 * 60)) % 60);
    var getHours = Math.floor((time_to_end / (1000 * 60 * 60)) % 24);
    var getDays = Math.floor(time_to_end / (1000 * 60 * 60 * 24));


    function run_time_sale() {
        getSeconds -= 1;
        if (getSeconds == 0 && getMinutes > 0) {
            getMinutes -= 1;
            getSeconds = 59;
            if (getMinutes == 0) {
                getHours -= 1;
                getMinutes = 59
                if (getHours == 0 && getDays != 0) {
                    getHours = 23;
                    getDays -= 1;
                }
            }
        }
        days.textContent = getDays.toString();
        hours.textContent = getHours.toString();
        minutes.textContent = getMinutes.toString();
        seconds.textContent = getSeconds.toString();
        if (getSeconds + getDays + getMinutes + getHours == 0) {
            clearInterval(saleInter);

            // Lắng nghe sự kiện click để hiển thị toast
            overTimeSale.show();

        }
    }
}
const chatZoom = document.getElementById("chatZoom");
const boxChat = document.getElementById("boxChat");
const askForChat = document.querySelector(".askForChat");
const textChat = document.querySelector(".text-sent");
chatZoom.addEventListener('click', (e) => {
    boxChat.style.display = "block";
})
function dropChat() {
    boxChat.style.display = "none";
}
function sendTextChat(request) {
    document.getElementById("chatForm").addEventListener('submit', (e) => {
        e.preventDefault();
    })
    var jqxhr = $.getJSON("../json/DataTrain.json", function (data) {
        $.each(data, function (key, value) {
            if (request.includes(key)) {
                $.each(value, function (subkey, subvalue) {
                    $.each(subvalue, function (resKey, resValue) {
                        if (request.includes(resKey)) {
                            document.getElementById("chat_content").innerHTML += `
        <div class="chat_line">
                <div class="sender float-end my-2">
                    <span><i class="fa fa-user text-black"></i>You</span>
                    <p class="text-sent p-1 rounded-1 bg-info">${request}</p>
                </div>
                <div class="reciever float-start">
                    <span><img src="./images/logo/logo_header.png" style="width: 20px; height: 20px"/>SeaBeauty</span>
                    <p class="text-replied p-1 rounded-1 bg-info">${resValue}</p>
                </div>
                <div class="clearfix">
                </div>
        </div>`;
                            askForChat.value = "";
                            return;
                        }
                    })
                })
            }
        })
    })
        .done(function () {
            console.log("second success");
        })
        .fail(function () {
            console.log("error");
        })
        .always(function () {
            console.log("complete");
        });
}
function fixQuantityOfProduct() {
    var editTotal = Number(document.getElementById("totalProduct").innerText.toString());
    editTotal = 0;
    const allNumberEachProduct = document.querySelectorAll(".inputQuantity");
    allNumberEachProduct.forEach(product => {
        if (product.value == 0) {
            $(document).ready(function () {
                $('[id*="' + product.id.substring(9, 17) + '"]').click();
            })
        }
        editTotal += Number(product.value);
    })
    document.getElementById("totalProduct").innerText = editTotal;
}

function UpdateQuantity(uid, masp) {
    fixQuantityOfProduct();
    var newquantity = document.getElementById("quantity_" + masp).value;
    alert(newquantity);
    fetch("http://localhost:3000/_productCart/" + masp + "?_userId=" + uid, {
        "method": "PATCH",
        "cache": "no-cache",
        "headers": {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ "soLuongMua": Number(newquantity) }),
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            }
            throw new Error('Network response was not ok.');
        });
}
function RemoveFromCart(uid, masp) {
    var accepted = confirm("Chấp nhận xóa");
    if (accepted) {
    fetch("http://localhost:3000/_productCart/" + masp + "?_userId=" + uid, {
        "method": "DELETE",
        "cache": "no-cache",
        "headers": {
            "Content-Type": "application/json",
        }
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            }
            throw new Error('Network response was not ok.');
        })
        .then(data => {
                var removeOnHtml = document.querySelector("." + masp);
                removeOnHtml.remove();
                fetch("http://localhost:3000/_productCart?_userId=" + uid, {
                    "method": "GET",
                    "cache": "no-cache",
                    "headers": {
                        "Content-Type": "application/json",
                    }
                }).then(data => {
                    if (data.ok) {
                        return data.json();
                    }
                    throw new Error('Network response was not ok.');
                })
                    .then(data => {
                        // Kiểm tra độ dài của mảng hoặc đối tượng JSON trả về
                        if (data.length == 0) {  // Nếu độ dài lớn hơn 3
                            // Bỏ class d-none cho phần tử có ID là showElement
                            document.getElementById("titleStatusByJs").innerHTML = "Bạn chưa có sản phẩm nào";
                            document.getElementById("statusByJs").classList.remove("d-none");
                        }
                    })// thiếu dấu } khiến toàn bộ file js ko load lên được =))
                    .catch(error => {
                        console.error('There has been a problem with your fetch operation:', error);
                    });
            
        })
        .catch(error => {
            console.error('There has been a problem with your fetch operation:', error);
            alert("Co loi khi xoa");
        });
    }
    else {
        let restoreValue = document.getElementById("quantity_" + masp);
        if (restoreValue <= 0) {
            restoreValue.value = 1;
        }
    }
}
// thêm slmua vào đường dẫn
function addSlMua() {
    btnMua.href += document.getElementById("slmua").value;
}

function updateTotalMoney(id, quantity, price) {
}