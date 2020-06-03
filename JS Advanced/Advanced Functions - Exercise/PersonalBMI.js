function getInformation(name,age,weight,height) {
    function getStatus(BMI) {
        if (BMI < 18.5) {
            return 'underweight';
        }
        else if(BMI < 25){
            return 'normal';
        }
        else if(BMI < 30){
            return 'overweight';
        }
        else if(BMI >= 30){
            return 'obese';
        }
    }
    let personBMI = Number((weight / (height/100)**2).toFixed(0));
    let personStatus = getStatus(personBMI);
    let info;
    if (personStatus == 'obese') {
        info =
        {
            'name':name,
            'personalInfo':
            {
                'age':age,
                'weight':weight,
                'height':height
            },
            'BMI':personBMI,
            'status':personStatus,
            'recommendation':'admission required'
        }
    }
    else
    {
        info =
        {
            'name':name,
            'personalInfo':
            {
                'age':age,
                'weight':weight,
                'height':height
            },
            'BMI':personBMI,
            'status':personStatus
        }
    }
    return info;
}
console.log(getInformation('Honey Boo Boo', 9, 57, 137));