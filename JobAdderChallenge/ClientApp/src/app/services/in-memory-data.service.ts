import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Job, JobDetail } from '../interfaces/job';

@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const jobs = [
      {
        "id": 1,
        "name": "Mobile Developer",
        "company": "Uberise"
      },
      {
        "id": 2,
        "name": "Reception",
        "company": "Surile"
      },
      {
        "id": 3,
        "name": "Admin Assistant",
        "company": "Genose"
      },
      {
        "id": 4,
        "name": "Head Chef",
        "company": "Bellile"
      },
      {
        "id": 5,
        "name": "Hospital Sales Representative",
        "company": "Contrado"
      },
      {
        "id": 6,
        "name": "Pharmacist",
        "company": "Yakindo"
      },
      {
        "id": 7,
        "name": "Visual Designer",
        "company": "Bonist"
      },
      {
        "id": 8,
        "name": "Carpenter",
        "company": "Ambideo"
      },
      {
        "id": 9,
        "name": "BDM",
        "company": "Susill"
      },
      {
        "id": 10,
        "name": "Dental Assistant",
        "company": "Syose"
      },
      {
        "id": 11,
        "name": "Kitchen Hand",
        "company": "Tare"
      },
      {
        "id": 12,
        "name": "Sales Executive",
        "company": "Protofic"
      },
      {
        "id": 13,
        "name": "Office Coordinator",
        "company": "Sucosis"
      },
      {
        "id": 14,
        "name": "Recruiter",
        "company": "Qualane"
      },
      {
        "id": 15,
        "name": "Truck Driver",
        "company": "Jazz"
      }
    ];
    const jobDetail = [
      {
        "id": 1,
        "name": "Mobile Developer",
        "company": "Uberise",
        "skills": "mobile, java, swift, objective-c, iOS, xcode, fastlane, aws, kotlin, hockey-app".split(',').map(x => x.trim())
      },
      {
        "id": 2,
        "name": "Reception",
        "company": "Surile",
        "skills": "detail, ms-office, word, outlook, data-entry, communication".split(',').map(x => x.trim())
      },
      {
        "id": 3,
        "name": "Admin Assistant",
        "company": "Genose",
        "skills": "administration, outlook, spreadsheets, housekeeping, ordering".split(',').map(x => x.trim())
      },
      {
        "id": 4,
        "name": "Head Chef",
        "company": "Bellile",
        "skills": "creativity, cooking, ordering, cleanliness, service".split(',').map(x => x.trim())
      },
      {
        "id": 5,
        "name": "Hospital Sales Representative",
        "company": "Contrado",
        "skills": "sales, pharmaceutical, clinical".split(',').map(x => x.trim())
      },
      {
        "id": 6,
        "name": "Pharmacist",
        "company": "Yakindo",
        "skills": "ahpra-registration, communication, prescriptions, advice".split(',').map(x => x.trim())
      },
      {
        "id": 7,
        "name": "Visual Designer",
        "company": "Bonist",
        "skills": "branding, design, powerpoint, photoshop, illustrator".split(',').map(x => x.trim())
      },
      {
        "id": 8,
        "name": "Carpenter",
        "company": "Ambideo",
        "skills": "carpentry, architecture, communication, detail".split(',').map(x => x.trim())
      },
      {
        "id": 9,
        "name": "BDM",
        "company": "Susill",
        "skills": "sales, networking, relationships, negotiation, multitasking".split(',').map(x => x.trim())
      },
      {
        "id": 10,
        "name": "Dental Assistant",
        "company": "Syose",
        "skills": "dental-assisting, reception, sterilisation, reliable".split(',').map(x => x.trim())
      },
      {
        "id": 11,
        "name": "Kitchen Hand",
        "company": "Tare",
        "skills": "cooking, washing, deliveries, organisation, hygiene".split(',').map(x => x.trim())
      },
      {
        "id": 12,
        "name": "Sales Executive",
        "company": "Protofic",
        "skills": "maturity, confidence, patience, relationships, service".split(',').map(x => x.trim())
      },
      {
        "id": 13,
        "name": "Office Coordinator",
        "company": "Sucosis",
        "skills": "reception, data-entry, ordering, detail".split(',').map(x => x.trim())
      },
      {
        "id": 14,
        "name": "Recruiter",
        "company": "Qualane",
        "skills": "recruiting, negotiation, placements, hr, admin".split(',').map(x => x.trim())
      },
      {
        "id": 15,
        "name": "Truck Driver",
        "company": "Jazz",
        "skills": "driver-license, reliable, communication, maintenance".split(',').map(x => x.trim())
      }
    ];

    return { jobs, jobDetail };
  }

  // Overrides the genId method to ensure that a hero always has an id.
  // If the heroes array is empty,
  // the method below returns the initial number (11).
  // if the heroes array is not empty, the method below returns the highest
  // hero id + 1.
  genId<T extends Job | JobDetail>(data: T[]): number {
    return data.length > 0 ? Math.max(...data.map(item => item.id)) + 1 : 11;
  }
}
