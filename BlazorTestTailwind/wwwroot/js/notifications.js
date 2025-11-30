// Toastify functions
window.showToast = (message, type, duration, isRtl) => {
    const backgroundColor = {
        success: "linear-gradient(to right, #00b09b, #96c93d)",
        error: "linear-gradient(to right, #ff5f6d, #ffc371)",
        warning: "linear-gradient(to right, #f093fb 0%, #f5576c 100%)",
        info: "linear-gradient(to right, #4facfe 0%, #00f2fe 100%)"
    };

    Toastify({
        text: message,
        duration: duration,
        gravity: "top",
        position: isRtl ? "left" : "right",
        style: {
            background: backgroundColor[type] || backgroundColor.info,
            direction: isRtl ? "rtl" : "ltr"
        },
        stopOnFocus: true
    }).showToast();
};

// SweetAlert functions
window.showSweetAlert = async (type, title, text, confirmText, cancelText, isRtl) => {
    const config = {
        title: title,
        text: text,
        icon: type,
        customClass: {
            popup: isRtl ? 'swal-rtl' : 'swal-ltr'
        }
    };

    if (type === 'confirm') {
        config.showCancelButton = true;
        config.confirmButtonText = confirmText;
        config.cancelButtonText = cancelText;
        config.confirmButtonColor = '#3085d6';
        config.cancelButtonColor = '#d33';
        
        const result = await Swal.fire(config);
        return result.isConfirmed;
    } else {
        await Swal.fire(config);
        return false;
    }
};

window.showSweetAlertInput = async (title, placeholder, inputType, isRtl) => {
    const result = await Swal.fire({
        title: title,
        input: inputType,
        inputPlaceholder: placeholder,
        showCancelButton: true,
        customClass: {
            popup: isRtl ? 'swal-rtl' : 'swal-ltr'
        },
        inputValidator: (value) => {
            if (!value) {
                return 'You need to write something!';
            }
        }
    });

    return result.isConfirmed ? result.value : null;
};