import 'package:flutter/material.dart';
import 'package:scr/src/constants/images.dart';
import 'package:scr/src/constants/sizes.dart';
import 'package:scr/src/constants/colors.dart';
import 'package:scr/src/features/models/model_user.dart';
import 'dart:math';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:scr/src/features/screens/login/enter_new_password.dart';

bool obscureText = true;

class CodeForResetPassword extends StatefulWidget {
  final User user;
  const CodeForResetPassword({Key? key, required this.user}) : super(key: key);

  @override
  State<CodeForResetPassword> createState() => _CodeForResetPasswordState();
}

class _CodeForResetPasswordState extends State<CodeForResetPassword> {
  late Size mediaSize;
  late int code;
  TextEditingController codeController = TextEditingController();

  @override
  void initState() {
    super.initState();
    generateCode();
    sendEmail();
  }

  Future<void> generateCode() async {
    int min = 100000;
    int max = 999999;

    // Create a Random object
    Random random = Random();

    // Generate a random 6-digit number
    int randomNumber = min + random.nextInt(max - min + 1);
    setState(() {
      code = randomNumber;
    });
  }

  Future sendEmail() async {
    final url = Uri.parse('https://api.emailjs.com/api/v1.0/email/send');
    const serviceId = "service_35f5igi";
    const templateId = "template_okhcbkk";
    const userId = "Gzp47JoNwGhKaXoZ3";
    final response = await http.post(url,
        headers: {
          'Content-Type': 'application/json',
          "origin": "http://ronalbo2610-001-site1.ftempurl.com"
        },
        body: json.encode({
          "service_id": serviceId,
          "template_id": templateId,
          "user_id": userId,
          "template_params": {
            "user_email": widget.user.email,
            "user_name": widget.user.name,
            "code": code,
          }
        }));
    return response.statusCode;
  }

  @override
  void dispose() {
    codeController.dispose();
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
              'We have sent a code to your email for reset password:',
              style: TextStyle(
                  color: Colors.black,
                  fontSize: 20,
                  fontWeight: FontWeight.w500),
              textAlign: TextAlign.center,
            ),
            const SizedBox(
              height: tFormHeight,
            ),
            const Text(
              'Enter your code here:',
              style: TextStyle(
                  color: Colors.black,
                  fontSize: 18,
                  fontWeight: FontWeight.w500),
              textAlign: TextAlign.center,
            ),
            const SizedBox(height: 20.0),
            _buildInputField('Code', codeController),
            const SizedBox(
              height: tFormHeight - 20,
            ),
            SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () {
                    if (codeController.text == code.toString()) {
                      Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => EnterNewPassword(
                            userId: widget.user.id,
                          ),
                        ),
                      );
                    } else {
                      Fluttertoast.showToast(
                          msg: "Wrong code",
                          toastLength: Toast.LENGTH_SHORT,
                          gravity: ToastGravity.CENTER);
                    }
                  },
                  child: Text('Accept code'),
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
