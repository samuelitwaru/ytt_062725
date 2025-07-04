function UC_PivotTable($) {
	  
	 this.setSDT_ProjectCollection = function(value) {
			this.SDT_ProjectCollection = value;
		}

		this.getSDT_ProjectCollection = function() {
			return this.SDT_ProjectCollection;
		} 
	 this.setSDT_EmployeeProjectMatrixCollection = function(value) {
			this.SDT_EmployeeProjectMatrixCollection = value;
		}

		this.getSDT_EmployeeProjectMatrixCollection = function() {
			return this.SDT_EmployeeProjectMatrixCollection;
		} 
	  
	  
	  

	var template = '<style>	/* Freeze the last 3 columns */	.project-header {		padding: 5px; 		background:#f5f5f5;	}		td.freeze, th.freeze {		position: sticky;		right: 0;		background-color: white; 		z-index: 2;		min-width:80px;	}		td.freeze-1, th.freeze-1 {		right: 0px;		margin-right:10px;	}		td.freeze-2, th.freeze-2 {		right: 80px;	}		td.freeze-3, th.freeze-3 {		right: 160px; 	}</style><div id=\"print\" style=\"overflow:scroll; scrollbar-width:none; border: 1px solid #dddddd; margin-right:-3px;\"> 		<table class=\"my-sticky-column-table\">				<thead  style=\"position:sticky; top:0; z-index:5\">			<tr>				<th id=\'firstHeaderData\' class=\'text-center\' style=\"position:sticky;left:0; background:white;\">Projects per employee:</th>				<!-- Project Header Cells Go Here -->				<th style=\"background:#f5f5f5;\" class=\"freeze freeze-3 work text-center\">Total Work Hours</th>				<th style=\"padding:5px; background:#f5f5f5;\" class=\"freeze freeze-2 leave text-center\">Total Leave Hours</th>				<th style=\"padding:5px; background:#f5f5f5;\" class=\"freeze freeze-1 leave text-center\">Total</th>			</tr>		</thead>				<tbody style=\'max-height:100px\'>			{{#SDT_EmployeeProjectMatrixCollection}}			<tr class=\"GridWithPaginationBar GridNoBorder WorkWithOdd text-center\">					<td id=\"{{EmployeeId}}\" style=\"font-weight: bold;background:#f5f5f5; position:sticky; left:0; z-index:1\" class=\'text-center\'><a class=\"employee-link\" id=\"link-{{EmployeeId}}\" href=\"\">{{EmployeeName}}</a></td>								<!-- Project Column Cells Go Here -->								<td class=\"freeze freeze-3 work text-center\" style=\"font-weight: bold;background:#f5f5f5;\">{{FormattedWorkHours}}</td>				<td class=\"freeze freeze-2 leave text-center\" style=\"font-weight: bold; background:#f5f5f5;\">{{FormattedLeaveHours}}</td>				<td class=\"freeze freeze-1 leave\" style=\"font-weight: bold; background:#f5f5f5;\">{{FormattedEmployeeHours}}</td>							</tr>			{{/SDT_EmployeeProjectMatrixCollection}}					</tbody>				<tfoot>			<tr class=\"GridWithPaginationBar GridNoBorder WorkWithOdd\">				<td id=\'project-footer\' class=\"text-center\" style=\"font-weight: bold;background:#fff; position:sticky; left:0; z-index:1\">Total</td>				<!-- Project Footer Cells Go Here -->				<td id=\'totalWorkHours\' class=\"freeze freeze-3 work text-center\" style=\"bold;background:#f5f5f5;\"></td>				<td class=\"freeze freeze-2 leave text-center project-header\" style=\"bold;background:#f5f5f5;\"></td>				<td class=\"freeze freeze-1 leave text-center project-header\" style=\"bold;background:#f5f5f5;\">{{FormattedOverallTotalHours}}</td>			</tr>		<tfoot>			</table></div><script type=\"text/javascript\">	function init(){		$(window).on(\'resize\', function() {			// Your code here			var newHeight = $(window).height();			$(\'#print\').css(\"max-height\", newHeight-100)			// Perform actions based on the new height		});	}    $(document).ready(function() {		init()  	});  </script>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnEmployeeClicked = 0; 
	var _iOnProjectClicked = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnEmployeeClicked = 0; 
			_iOnProjectClicked = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='EmployeeClicked']")
				.on('employeeclicked', this.onEmployeeClickedHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='ProjectClicked']")
				.on('projectclicked', this.onProjectClickedHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

					const UC = this;
					
					function aggregateProjects(employeeData) {
						// Object to store project details with ProjectId as the key
						const projectSummary = {};
					
						// Iterate through the employee data
						employeeData.forEach(employee => {
							const projects = employee.Projects || [];
							projects.forEach(project => {
								const projectId = project.ProjectId;
								const projectName = project.ProjectName.trim();
								const projectHours = project.ProjectHours;
					
								if (!projectSummary[projectId]) {
									// Add new project to the dictionary
									projectSummary[projectId] = {
										ProjectId: projectId,
										ProjectName: projectName,
										ProjectHours: projectHours
									};
								} else {
									// Update the hours for existing project
									projectSummary[projectId].ProjectHours += projectHours;
								}
							});
						});
					
						// Convert the dictionary to an array and sort by ProjectName
						const uniqueProjects = Object.values(projectSummary);
						uniqueProjects.sort((a, b) => a.ProjectName.toLowerCase().localeCompare(b.ProjectName.toLowerCase()));
					
						return uniqueProjects;
					}
				
					function getUniqueProjects(employeeData) {
						const projectsMap = new Map();
						
						employeeData.forEach(employee => {
							if (employee.Projects) {
								employee.Projects.forEach(project => {
									projectsMap.set(project.ProjectId, project);
								});
							}
						});
						
						// Convert the map values to an array and sort alphabetically by ProjectName
						const uniqueProjects = Array.from(projectsMap.values()).sort((a, b) => {
							return a.ProjectName.trim().localeCompare(b.ProjectName.trim());
						});
						
						return uniqueProjects;
					}
				
					function appendProjectHeaders(projects) {
						// Find the element with id 'firstHeaderData'
						const firstHeader = $('#firstHeaderData');
						
						// Iterate through the projects array
						projects.reverse().forEach(project => {
							// Create a new <th> element with the project name
							const th = $('<th>')
							th.html(`<a id="link-${project.ProjectId}" href='' class="project-link">${project.ProjectName.trim()}</a>`)
							th.addClass('project-header')
							th.addClass('text-center')
							th.on('click', e=>{
								e.preventDefault()
							})
							// Append the new <th> element right after the firstHeader
							firstHeader.after(th);
							
							// Update firstHeader to point to the newly added <th> for subsequent appends
							firstHeader.next();
						});
					}
				
					function addProjectColumnsToRows(projects) {
						
						// Iterate over all rows in the table
						$('table tr').each(function () {
							// Find the first <td> element in the row
							const firstCell = $(this).find('td').first();
							
							// Add a <td> for each project in the sorted project list
							projects.forEach(project => {
								const td = $('<td>').text(''); // Create an empty <td> for each project
								td[0].id = `${firstCell[0]?.id}-${project.ProjectId}`
								firstCell.after(td);
								
								// Update firstCell to reference the newly added <td> for subsequent appends
								firstCell.next();
							});
						});
					}
				
					function safeParseInt(value) {
						const parsed = parseInt(value, 10);
						return isNaN(parsed) ? 0 : parsed;
					}
					
					function populateHours(SDT_EmployeeProjectMatrixCollection){
						for (let i = 0; i < SDT_EmployeeProjectMatrixCollection.length; i++) {
							
							var employee = SDT_EmployeeProjectMatrixCollection[i]
							var employeeId = employee.EmployeeId
							var projects = employee.Projects
							if (projects) {
								for (let j=0; j < projects.length; j++) {
									var project = projects[j]
									var cell = document.getElementById(`${employeeId}-${project.ProjectId}`)
									cell.innerHTML = convertMinutesToHours(project.ProjectHours)
								}
							}
						}
					}
				
					function populateProjectTotalHours(projects){
						let totalWorkHours = 0
						projects.forEach(project => {
							const tdElement = document.getElementById(`project-footer-${project.ProjectId}`);
							tdElement.classList.add('text-center')
							tdElement.classList.add('project-header')
							if (tdElement) {
								totalWorkHours += project.ProjectHours
								tdElement.innerHTML = convertMinutesToHours(project.ProjectHours);
							}
						});
						$('#totalWorkHours').html(convertMinutesToHours(totalWorkHours))
					}
					
					function convertMinutesToHours(minutes) {
						// Calculate hours and remaining minutes
						const hours = Math.floor(minutes / 60);
						const remainingMinutes = minutes % 60;
						
						// Format hours and minutes as two-digit strings
						const formattedHours = String(hours).padStart(2, '0');
						const formattedMinutes = String(remainingMinutes).padStart(2, '0');
						
						// Return the formatted time string
						return `${formattedHours}:${formattedMinutes}`;
					}
				
					function addClickEvents(){
						var projectLinks = document.getElementsByClassName('project-link')
						for (let i=0; i < projectLinks.length; i++) {
							var element = projectLinks[i]
							element.onclick = (event) => {
								event.preventDefault()
								var projectId = parseInt(event.target.id.replace('link-',''))
								UC.CurrentProjectId = projectId
								UC.ProjectClicked()
							}
						}
						
						var employeeLinks = document.getElementsByClassName('employee-link')
						for (let i=0; i < employeeLinks.length; i++) {
							var element = employeeLinks[i]
							element.onclick = (event) => {
								event.preventDefault()
								var employeeId = parseInt(event.target.id.replace('link-',''))
								UC.CurrentEmployeeId = employeeId
								UC.EmployeeClicked()
							}
						}
					}
					
					const projects = aggregateProjects(this.SDT_EmployeeProjectMatrixCollection)
					console.log(aggregateProjects(this.SDT_EmployeeProjectMatrixCollection))
					appendProjectHeaders(projects)
					addClickEvents()
					addProjectColumnsToRows(projects)
					populateHours(this.SDT_EmployeeProjectMatrixCollection)
					populateProjectTotalHours(projects)
					this.toggleLeave()
					var newHeight = $(window).height();
					$('#print').css("max-height", newHeight-100)
				
		}
		this.Refresh = function() {

					this.show()
				
		}
		this.toggleLeave = function() {

					var elements = document.getElementsByClassName("leave");
					var workElements = document.getElementsByClassName("work");
					
					for (var i = 0; i < elements.length; i++) {
						
						if (this.ShowLeaveTotal=='true') {
							elements[i].classList.remove("hidden");
							} else {
							elements[i].classList.add("hidden");
						}
					}
				
					for (var i = 0; i < workElements.length; i++) {
						
						if (this.ShowLeaveTotal=='true') {
							workElements[i].style.right = 100
						} else {
							workElements[i].style.right = 0
						}
					}
				
		}


		this.onEmployeeClickedHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 this.SDT_ProjectCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.SDT_EmployeeProjectMatrixCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
			}

			if (this.EmployeeClicked) {
				this.EmployeeClicked();
			}
		} 

		this.onProjectClickedHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 this.SDT_ProjectCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 this.SDT_EmployeeProjectMatrixCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
			}

			if (this.ProjectClicked) {
				this.ProjectClicked();
			}
		} 

	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}