
const swiperProduct = new Swiper('#swiper_product', {
    direction: 'horizontal',
    slidesPerView: 'auto',
    calculateHeight: true,
    loop: true,
    autoplay: {
        delay: 3000,
    },
    cudeEffect: {
        shadow: true,
        shadowScale: 0.3
    },
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
    breakpoints: {
        768: {
            slidesPerView: 4,
        },
        992: {
            slidesPerView: 5,
        }
    },
    speed: 400,
    spaceBetween: 0
});
const swiperAdvert = new Swiper('#swiper_advert', {
    direction: 'horizontal',
    calculateHeight: true,
    loop: true,
    autoplay: {
        delay: 3000,
    },
    cudeEffect: {
        shadow: true,
        shadowScale: 0.3
    },
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
    speed: 400,
    spaceBetween: 0,
    slidesPerView: 1
});