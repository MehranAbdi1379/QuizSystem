﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuizSystem.Domain.Exceptions {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ExceptionMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("QuizSystem.Domain.Exceptions.ExceptionMessages", typeof(ExceptionMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Student already exists and can not be added to the course.
        /// </summary>
        public static string CourseAddStudentAlreadyExistsExceptionMessage {
            get {
                return ResourceManager.GetString("CourseAddStudentAlreadyExistsExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to End time for the course is before start time.
        /// </summary>
        public static string CourseEndTimeIsBeforeStartTimeExceptionMessage {
            get {
                return ResourceManager.GetString("CourseEndTimeIsBeforeStartTimeExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Course Id doesn&apos;t exist to add to CourseProfessor model.
        /// </summary>
        public static string CourseProfessorCourseIdNotExistExceptionMessage {
            get {
                return ResourceManager.GetString("CourseProfessorCourseIdNotExistExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Professor is null for course.
        /// </summary>
        public static string CourseProfessorNotExistExceptionMessage {
            get {
                return ResourceManager.GetString("CourseProfessorNotExistExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Professor Id doesn&apos;t exist to add to CourseProfessor model.
        /// </summary>
        public static string CourseProfessorProfessorIdNotExistExceptionMessage {
            get {
                return ResourceManager.GetString("CourseProfessorProfessorIdNotExistExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Time period is too short for a course.
        /// </summary>
        public static string CourseShortPeriodExceptionMessage {
            get {
                return ResourceManager.GetString("CourseShortPeriodExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start time for course is in the past.
        /// </summary>
        public static string CourseStartTimeInThePastExceptionMessage {
            get {
                return ResourceManager.GetString("CourseStartTimeInThePastExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Student is null for adding to course.
        /// </summary>
        public static string CourseStudentAddNullExceptionMessage {
            get {
                return ResourceManager.GetString("CourseStudentAddNullExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Course Id doesn&apos;t exist to add to CourseStudent model.
        /// </summary>
        public static string CourseStudentCourseIdNotExistExceptionMessage {
            get {
                return ResourceManager.GetString("CourseStudentCourseIdNotExistExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Student Id doesn&apos;t exist to add to CourseStudent model.
        /// </summary>
        public static string CourseStudentStudentIdNotExistExceptionMessage {
            get {
                return ResourceManager.GetString("CourseStudentStudentIdNotExistExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Title already exists.
        /// </summary>
        public static string CourseTitleExistsExceptionMessage {
            get {
                return ResourceManager.GetString("CourseTitleExistsExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Course does not exist to add to Professor.
        /// </summary>
        public static string ProfessorAddCourseNotExistExceptionMessage {
            get {
                return ResourceManager.GetString("ProfessorAddCourseNotExistExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The birthdate is too old or too young.
        /// </summary>
        public static string ProfessorBirthDateInvalidValueExceptionMessage {
            get {
                return ResourceManager.GetString("ProfessorBirthDateInvalidValueExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to FirstName is Required for Professor.
        /// </summary>
        public static string ProfessorFirstNameRequiredExceptionMessage {
            get {
                return ResourceManager.GetString("ProfessorFirstNameRequiredExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LastName is Required for Professor.
        /// </summary>
        public static string ProfessorLastNameRequiredExceptionMessage {
            get {
                return ResourceManager.GetString("ProfessorLastNameRequiredExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to National Code already exists.
        /// </summary>
        public static string ProfessorNationalCodeExistsExceptionMessage {
            get {
                return ResourceManager.GetString("ProfessorNationalCodeExistsExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Professor NationalCode is invalid.
        /// </summary>
        public static string ProfessorNationalCodeInvalidExceptionMessage {
            get {
                return ResourceManager.GetString("ProfessorNationalCodeInvalidExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to National Code already exists.
        /// </summary>
        public static string StudentNationalCodeExistsExceptionMessage {
            get {
                return ResourceManager.GetString("StudentNationalCodeExistsExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Student NationalCode is invalid.
        /// </summary>
        public static string StudentNationalCodeInvalidException {
            get {
                return ResourceManager.GetString("StudentNationalCodeInvalidException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The birthdate is too old or too young.
        /// </summary>
        public static string UserBirthDateInvalidValueExceptionMessage {
            get {
                return ResourceManager.GetString("UserBirthDateInvalidValueExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to FirstName is Required for User.
        /// </summary>
        public static string UserFirstNameRequiredExceptionMessage {
            get {
                return ResourceManager.GetString("UserFirstNameRequiredExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LastName is Required for User.
        /// </summary>
        public static string UserLastNameRequiredExceptionMessage {
            get {
                return ResourceManager.GetString("UserLastNameRequiredExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password for User isn&apos;t sufficient.
        /// </summary>
        public static string UserPasswordInvalidExceptionMessage {
            get {
                return ResourceManager.GetString("UserPasswordInvalidExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User search type is invalid.
        /// </summary>
        public static string UserSearchTypeInvalidExceptionMessage {
            get {
                return ResourceManager.GetString("UserSearchTypeInvalidExceptionMessage", resourceCulture);
            }
        }
    }
}
