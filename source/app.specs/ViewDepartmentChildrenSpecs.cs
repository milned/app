using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using app.web.application;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    [Subject(typeof (ViewDepartmentChildren))]
    public class ViewDepartmentChildrenSpecs
    {
        public abstract class concern : Observes<ISupportAStory,
                                            ViewDepartmentChildren>
        {

        }

        public class when_run : concern
        {

            private Establish c = () =>
                                      {
                                          department_repository = depends.on<IFindDepartments>();
                                          
                                          department_repository.setup(x => x.get_sub_departments(request)).Return(
                                              SubDepartment);
                                      };


            private Because b = () => { sut.run(request); };

            private It should_display_all_sub_departments = () =>
                                                                {
                                                                    displayEngine.received(x => x.display(SubDepartment));
                                                                };

            private static IDisplayReports displayEngine;
            private static object SubDepartment;
            private static IProvideDetailsForACommand request;
            private static IFindDepartments department_repository;
        }

    }
}
