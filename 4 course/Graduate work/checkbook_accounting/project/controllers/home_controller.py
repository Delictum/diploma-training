from flask import send_file

from project.controllers.user_controller import *


@app.route('/')
@app.route('/index')
@app.route('/home')
@app.route('/home/index')
def index():
    # ...
    return render_template("home/index.html")


@app.route('/about')
@app.route('/home/about')
def about():
    # ...
    return render_template("home/about.html", title='О сайте')


@app.route('/privacy_policy')
@app.route('/home/privacy_policy')
@app.route('/privacy-policy')
@app.route('/home/privacy-policy')
def privacy_policy():
    # ...
    return render_template("home/privacy_policy.html", title='Политика конфеденциальности')


@app.route('/agreement')
@app.route('/home/agreement')
def agreement():
    # ...
    return render_template("home/agreement.html", title='Пользовательское соглашение')


@app.route("/download_apk", methods=['GET', 'POST'])
@app.route("/download-apk", methods=['GET', 'POST'])
def download_apk():
    return send_file(os.path.normpath("static/apk/app_v.1.0.2.apk"), as_attachment=True)
