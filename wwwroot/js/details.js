function expandInfo(e) {
    const isHidden = document.querySelector('.overflow-hidden-y');
    const isVisible = document.querySelector('.overflow-visible-y');
    if (isHidden == null) {
        isVisible.classList.replace('overflow-visible-y', 'overflow-hidden-y');
        e.innerHTML = "Xem thêm nội dung <span><i class='fa fa-angle-double-down'></i></span>";
    }
    else {
        isHidden.classList.replace('overflow-hidden-y', 'overflow-visible-y');
        e.innerHTML = "Thu gọn nội dung <span><i class='fa fa-angle-double-up'></i></span>";
    }

    const block = document.querySelector('.block_expand_details');
    const expand = document.querySelector('.expand_info');
    if (block != null) {

        block.classList.replace('block_expand_detail', 'expand_info');
    }
    else {
        expand.classList.replace('expand_info', 'block_expand_detail');
    }
}