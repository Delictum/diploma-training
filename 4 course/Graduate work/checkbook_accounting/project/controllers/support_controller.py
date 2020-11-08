from project.controllers.user_controller import *


@app.route('/support')
@app.route('/support/')
@app.route('/support/index')
def support_index():
    # ...
    return render_template("support/index.html")
