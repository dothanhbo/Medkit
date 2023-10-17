import 'package:flutter/material.dart';
import 'package:scr/src/constants/images.dart';
import 'package:scr/src/constants/sizes.dart';
import 'package:scr/src/constants/texts.dart';
import 'package:scr/src/constants/colors.dart';
import 'package:scr/src/features/controllers/user_controller.dart';

bool obscureText = true;

class ForgetPassword extends StatefulWidget {
  const ForgetPassword({Key? key}) : super(key: key);

  @override
  State<ForgetPassword> createState() => _ForgetPasswordState();
}

class _ForgetPasswordState extends State<ForgetPassword> {
  late Size mediaSize;
  TextEditingController emailController = TextEditingController();
  bool rememberUser = false;

  @override
  void dispose() {
    // Clean up the controller when the widget is removed from the widget tree.
    // This also removes the _printLatestValue listener.
    emailController.dispose();
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
              'Forgot Password',
              style: TextStyle(
                  color: Colors.black,
                  fontSize: 30,
                  fontWeight: FontWeight.w500),
              textAlign: TextAlign.center,
            ),
            const SizedBox(
              height: tFormHeight,
            ),
            const Text(
              'Please enter your email',
              style: TextStyle(
                  color: Colors.black,
                  fontSize: 20,),
              textAlign: TextAlign.center,
            ),
            _buildInputField(tEmail, emailController),
            const SizedBox(
              height: tFormHeight - 20,
            ),
            const SizedBox(
              height: tFormHeight - 20,
            ),
            SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () {
                    String email = emailController.text;
                    checkEmail(context, email);
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

  Widget _buildInputField(String text, TextEditingController controller) {
    return TextFormField(
      controller: controller,
      decoration: InputDecoration(
          prefixIcon: const Icon(Icons.person_outline_outlined),
          labelText: text,
          hintText: text,
          border: const OutlineInputBorder(),
          suffixIcon: const IconButton(
            onPressed: null,
            icon: Icon(null),
          )),
    );
  }
}
