// Xử lý toggle sidebar từ nút trên navbar
document.getElementById('sidebarToggle')?.addEventListener('click', function () {
    document.getElementById('toggleSidebar').click();
});

// Kiểm tra cookie khi tải trang
document.addEventListener('DOMContentLoaded', function () {
    const isCollapsed = document.cookie.split('; ').find(row => row.startsWith('sidebarCollapsed='))?.split('=')[1] === 'true';
    if (isCollapsed) {
        document.getElementById('sidebar').classList.add('collapsed');
    }
});