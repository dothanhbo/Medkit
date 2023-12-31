import 'package:flutter/material.dart';
import 'package:scr/src/features/models/model_disease.dart';
import 'package:scr/src/constants/colors.dart';
import 'package:scr/src/features/screens/disease/disease_detail.dart';
import 'package:scr/src/features/controllers/disease_controller.dart';
import 'package:scr/src/constants/images.dart';
class PopularDisease extends StatefulWidget {
  const PopularDisease({Key? key}) : super(key: key);
 @override
  State<PopularDisease> createState() => _PopularDiseaseState();
}

class _PopularDiseaseState extends State<PopularDisease> {
  List<Disease> diseases = [];

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  Future<void> fetchData() async {
      List<Disease> fetchedDiseases = await getAllDiseases();
      setState(() {
        diseases = fetchedDiseases;
        diseases[0].image = allergic;
        diseases[1].image = cough;
        diseases[2].image = fever;
        diseases[3].image = diarrhea;
        diseases[4].image = flu;
        diseases[5].image = covid;
      });
  }


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title:const Text(
          'Popular diseases',
          style: TextStyle(
              fontFamily: 'Montserrat',
              fontSize: 18,
              fontWeight: FontWeight.bold),
          )
      ),
      body:Container(
        color: tOnBoardingPage1Color,
        child: ListView.builder(
        itemCount: diseases.length,
        itemBuilder: (context, index) {
        final item = diseases[index];
        return ListTile(
          title: Text(
            item.name,
            style:const TextStyle(
              color: Colors.black,
              fontFamily: 'Montserrat',
              fontSize: 18,
              fontWeight: FontWeight.bold,
              decoration: TextDecoration.underline),
            ),
            trailing:const Icon(Icons.arrow_forward_ios_rounded),
            onTap: (){
              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => DiseaseDetail(disease: diseases[index]))
                  );
            }
              );
            },
        )
    )
    );
  }
}