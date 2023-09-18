
// Set - ExecutionPolicy - ExecutionPolicy RemoteSigned: solve the error when run gulp sass, select Y
// protect from script not trust
var gulp = require('gulp'),
    cssmin = require("gulp-cssmin")
rename = require("gulp-rename");
const sass = require('gulp-sass')(require('sass'));

gulp.task('sass', function () {
    return gulp.src('wwwroot/scss/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(cssmin())
        .pipe(rename({
            suffix: ".min" // *.min.css, .min: minified version, remove unecessary code
        }))
        .pipe(gulp.dest('wwwroot/css/'));
});
// auto reload file when change
gulp.task('watching', function () {
    return gulp.watch('wwwroot/scss/*.scss', gulp.series('sass'));
})
//Với định nghĩa như trên, bạn tạo ra hai loại tác vụ có tên là sass và default

//Để thi hành tác vụ sass chỉ cần gõ lệnh:

//gulp sass
//Tác vụ này thực hiện build các file SCSS ở đường dẫn wwwroot / scss/**/ *.scss thành css lưu kết quả tại wwwroot / css /, sau đó tối ưu hóa lưu tại wwwroot / css / min /

//    Còn tác vụ mặc định default chỉ cần gõ gulp là hoạt động, tác vụ này giám sát thay đổi file scss, nếu có thay đổi thì chạy ngay tác vụ sass


//Như vậy từ đây, chỉ cần biên tập mã nguồn SCSS - lập tức có kết quả CSS trong dự án

//gulp.js site.scss -> site.css
//Đây là ví dụ gulp biên dịch scss từ file assets / scss / site.scss thành CSS lưu tại wwwroot / css / site.css, nếu muốn có hậu tố min thì bỏ commet suffix

