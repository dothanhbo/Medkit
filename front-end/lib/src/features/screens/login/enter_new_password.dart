import 'package:flutter/material.dart';
import 'package:scr/src/constants/images.dart';
import 'package:scr/src/constants/sizes.dart';
import 'package:scr/src/constants/texts.dart';
import 'package:scr/src/constants/colors.dart';
import 'package:scr/src/features/controllers/user_controller.dart';

bool obscureText = true;

class EnterNewPassword extends StatefulWidget {
  final String userId;
  const EnterNewPassword({
    Key? key,
    required this.userId
    }) : super(key: key);

  @override
  State<EnterNewPassword> createState() => _EnterNewPasswordState();
}

class _EnterNewPasswordState extends State<EnterNewPassword> {
  late Size mediaSize;
  TextEditingController passwordController = TextEditingController();
  TextEditingController confirmPasswordController = TextEditingController();

  bool rememberUser = false;

  @override
  void dispose() {
    passwordController.dispose();
    confirmPasswordController.dispose();

    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    mediaSize = MediaQuery.of(context).size;
    return SafeArea(
      child: Scaffold(
        backgroundColor: tOnBoardingPage1Color,
        body: Stack(
          children: [
            Positioned(top: 30, child: _buildTop()),
            Positioned(bottom: 0, child: _buildBottom()),
          ],
        ),
      ),
    );
  }

  Widget _buildTop() {
    return SizedBox(
      width: mediaSize.width,
      child: const Image(
        image: AssetImage(logo),
        height: 150,
      ),
    );
  }

  Widget _buildBottom() {
    return SizedBox(
      width: mediaSize.width,
      height: 520,
      child: Card(
        shape: const RoundedRectangleBorder(
            borderRadius: BorderRadius.only(
          topLeft: Radius.circular(30),
          topRight: Radius.circular(30),
        )),
        child: Padding(
            padding: const EdgeInsets.all(20.0), child: _buildFormLogin()),
      ),
    );
  }

  Widget _buildFormLogin() {
    return Form(
      child: Container(
        padding: const EdgeInsets.symmetric(vertical: tFormHeight - 20),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const Text(
              'New password:',
              style: TextStyle(
                  color: Colors.black,
                  fontSize: 30,
                  fontWeight: FontWeight.w500),
              textAlign: TextAlign.center,
            ),
            const SizedBox(
              height: tFormHeight,
            ),
            _buildPasswordInputField(tPassword, passwordController),
            const SizedBox(
              height: tFormHeight - 20,
            ),
            _buildPasswordInputField(
                tConfirmPassword, confirmPasswordController),
            const SizedBox(
              height: tFormHeight - 20,
            ),
            SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () {
                    String password = passwordController.text;
                    String confirmPassword = confirmPasswordController.text;
                    changePassword(context, widget.userId, password, confirmPassword);
                  },
                  child: Text(tLogin.toUpperCase()),
                )),
            const SizedBox(
              width: double.infinity,
              height: tFormHeight - 10,
            ),
           
          ],
        ),
      ),
    );
  }

  Widget _buildPasswordInputField(
      String text, TextEditingController controller) {
    return TextFormField(
      controller: controller,
      obscureText: obscureText,
      decoration: InputDecoration(
          prefixIcon: const Icon(Icons.fingerprint),
          labelText: text,
          hintText: text,
          border: const OutlineInputBorder(),
          suffixIcon: IconButton(
            onPressed: () {
              setState(() {
                obscureText = !obscureText;
              });
              print(obscureText);
            },
            icon: const Icon(Icons.remove_red_eye_sharp),
          )),
    );
  }
}
