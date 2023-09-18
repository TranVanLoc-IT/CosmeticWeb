
// Lấy tham chiếu đến toast element
var overTimeSale = new bootstrap.Toast(document.getElementById('informOverSale'));

window.onload = function () {
    const days = document.querySelector(".days");
    const hours = document.querySelector(".hours");
    const minutes = document.querySelector(".minutes");
    const seconds = document.querySelector(".seconds");

    var saleInter = setInterval(run_time_sale, 1000);

    const date_now = new Date();
    const date_end = new Date("2023/09/08, 21:57:00");
    const time_to_end = Math.abs(date_now - date_end);// miliseconds
    if (date_now > date_end) {
        $(document).ready(function () {
            $('.event_sale').css('display','none')
        })
        return;
    }

    var getSeconds = time_to_end < 0 ? 0 : Math.floor((time_to_end % (1000 * 60)) / 1000); // -> giây 1000 -> 60 phút, lấy dư vì chỉ có 60s không vượt quá
    var getMinutes = time_to_end < 0 ? 0 : Math.floor((time_to_end % (1000 * 60 * 60)) / (1000 * 60));// dư của giây *phút * giờ / giây * phút
    var getHours = time_to_end < 0 ? 0 : Math.floor(time_to_end / (1000 * 60 * 60)); // giây * phút * giờ

    var getDays = time_to_end < 0 ? 0 : Math.floor((time_to_end / 86400000))

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
function sendTextChat() {
    document.getElementById("chatForm").addEventListener('submit',(e) => {
        e.preventDefault();
    })
    textChat.textContent = askForChat.value;
    askForChat.value = "";    
}
