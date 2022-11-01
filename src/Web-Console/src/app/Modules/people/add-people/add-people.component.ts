import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonService } from 'src/app/services/person.service';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SkillPersonMapVm } from 'src/app/models/SkillPersonMapVm';
import { PersonVm } from 'src/app/models/PersonVm';
import { SkillVm } from 'src/app/models/SkillVm';
import { CountryVm } from 'src/app/models/CountryVm';
import { CityVm } from 'src/app/models/CityVm';

@Component({
  selector: 'app-add-people',
  templateUrl: './add-people.component.html',
  styleUrls: ['./add-people.component.scss']
})
export class AddPeopleComponent implements OnInit {

  isEditing: boolean = false;
  // @ts-ignore
  form: FormGroup;
  model: PersonVm;
  //display: FormControl = new FormControl("", Validators.required);
  skills: SkillVm[] = [];
  countryList: CountryVm[] = [];
  public cityList: CityVm[] = [];
  public isSkillSelected: boolean = true;

  constructor(
    public activateRoute: ActivatedRoute,
    public service: PersonService,
    public builder: FormBuilder,
    private router: Router
  ){
    this.model = new PersonVm();
    this.service.getSkills().subscribe(c => {
      this.skills = c;
    });

    this.service.getCountryList().subscribe(c => {
      this.countryList = c;
    });
    this.createForm();
  }

  ngOnInit(): void{
    this.form.get('countryId')?.valueChanges.subscribe(c => {
      console.log(c)
      if (c && c > 0){
        this.service.getCityListBycountryId(c).subscribe(res => {
          this.cityList = res;
        });
      } else this.cityList = [];

    });

    this.activateRoute.params.subscribe(data => {
      if (data && data['id']){
        this.isEditing = true;
        this.edit(data['id']);
      }
    });
  }


  public getSkillValidate(){
    if (this.skills.length > 0){
      console.log(this.skills.some(c => c.checked))
      return this.skills.some(c => c.checked);
    }
    return false;
  }

  // @ts-ignore
  createForm(data: PersonVm = null): void{
    if (data){
      this.model = data;
    }
    // @ts-ignore
    this.form = this.builder.group({
      id: this.model.id,
      name: [this.model.name, Validators.required],
      cityId: [this.model.cityId ?? 0 > 0 ? this.model.cityId : ''],
      countryId: [this.model.countryId ?? 0 > 0 ? this.model.countryId : ''],
      resumeUrl: [this.model.resumeUrl],
      resumeFile: [this.model.resumeFile, Validators.required],
      doB: [this.model.doB, Validators.required],
      skillPersonMapList: this.skillPersonMapList([]),

    });
  }

  skillPersonMapList(dataList: SkillPersonMapVm[]): FormArray{
    const formArray = new FormArray([]);
    if (dataList?.length > 0){
      dataList.forEach(data => {
        const singleForm = this.builder.group({
          id: data.id,
          skillId: data.skillId,
          personId: data.personId,
        });
        // @ts-ignore
        formArray.push(singleForm);
      });
    }
    // @ts-ignore
    return formArray;
  }

  addOrUpdate(form: FormGroup): void{
    if (form.invalid || !this.getSkillValidate()){
      form.markAsPristine()
      return;
    }
    let skillPersonMapList: SkillPersonMapVm[] = [];
    if (this.skills.length > 0){
      form.get('skillPersonMapList')?.setValue([]);
      this.skills.forEach(item => {
        if (item.checked){
          //@ts-ignore
          let model: SkillPersonMapVm = this.model.skillPersonMapList.find(c => c.skillId == item.id);
          skillPersonMapList.push(model ? model : {...new SkillPersonMapVm(), skillId: item.id, personId: this.model.id});
        }
      });
    }
    this.model = {...this.model, ...form.value, skillPersonMapList: skillPersonMapList};
    console.log(this.model);
    this.service.post(this.model).subscribe(c => {
      this.router.navigate([`/person/create`]);
    });

  }

  edit(id: number): void{
    this.service.getById(id).subscribe(c => {
      if (c){
        this.model = c;
        c.skillPersonMapList.forEach(item => {
          this.skills.forEach(skill => {
            if (item.skillId === skill.id){
              skill.checked = true;
            }
          });
        });

        this.isSkillSelected = !this.skills.some(c => c.checked);
        if (c.countryId){
          this.service.getCityListBycountryId(c.countryId).subscribe(res => {
            this.cityList = res;
            this.createForm();
          });
        } else this.createForm();
      }
    });
  }

  public itemChecked(id: number, event: any): void{
    const checked = event.target.checked;
    if (checked){
      this.skills.forEach(item => {
        if (item.id === id){
          item.checked = true;
        }
      });
      this.isSkillSelected = !this.skills.some(c => c.checked);
      return;
    }
    this.skills.forEach(item => {
      if (item.id === id){
        item.checked = false;
      }
    });
    this.isSkillSelected = !this.skills.some(c => c.checked);
  }

  public onFileChange($event: Event): void{
    // @ts-ignore
    const file: File = $event.target.files[0];
    console.log(file);
    // check file type pdf and doc only

    if (file.type === 'application/pdf' || file.type === 'application/msword' || file.type === 'application/vnd.openxmlformats-officedocument.wordprocessingml.document'){
      this.form.get('resumeFile')?.setValue(file);
      this.form.get('resumeFile')?.updateValueAndValidity();
    } else{
      this.form.get('resumeFile')?.setErrors({fileType: true});
    }


  }


}
